using Aim_Trainer.GameData;
using Microsoft.VisualBasic;
using System.Globalization;

namespace Aim_Trainer.RankingList
{
    public class RankingRepository
    {
        private readonly RankingDatabase database = new RankingDatabase();
        public void Add(RankingEntry entry)
        {
            database.Add(entry);
            WholeList.Add(entry);
        }

        public List<RankingEntry> GetAll()
        {
            return database.GetAll();
        }

        public List<RankingEntry> GetByDifficulty(GameSettings.Difficulty difficulty)
        {
            return database.GetByDifficulty(difficulty);
        }

        public void ShowRankingAccordingToDifficulty(GameSettings.Difficulty difficultyLevel)
        {
            var list = GetByDifficulty(difficultyLevel);

            if (list.Count == 0)
            {
                MessageBox.Show($"Noch keine Einträge für {difficultyLevel}.");
                return;
            }
            ShowList(list, "Rangliste von " + difficultyLevel, medals: true);
        }


        private readonly GameSettings _settings = new();
        public List<RankingEntry> WholeList { get; private set; } = [];
        public string LastEnteredName
        {
            get
            {
                if (WholeList.Count == 0)
                    return "";
                return WholeList[WholeList.Count - 1].Username;
            }
        }

        public RankingRepository()
        {
            LoadOrCreateWholeList();
        }


        //liest daten wieder ein damit die Rangliste wieder angezeigt werden kann nach schließen
        public void LoadOrCreateWholeList()
        {
            WholeList = database.GetAll();
        }

        public List<RankingEntry> BestUsers() =>
             [.. WholeList.GroupBy(e => e.Username, StringComparer.OrdinalIgnoreCase)
                     .Select(gruppe => gruppe.OrderByDescending(e => e.Score).First())
                     .OrderByDescending(e => e.Score)];

        public List<RankingEntry> BestUserforDifficulties(GameSettings.Difficulty stufe) =>
            [.. WholeList.Where(e => e.Difficulty == stufe)
                     .GroupBy(e => e.Username, StringComparer.OrdinalIgnoreCase)
                     .Select(gruppe => gruppe.OrderByDescending(e => e.Score).First())
                     .OrderByDescending(e => e.Score)];


        public List<RankingEntry> HistorieFilter(string username) =>
            [.. WholeList.Where(entry => entry.Username.Equals(
                username, StringComparison.OrdinalIgnoreCase)).
                OrderByDescending(entry => entry.CreationDate)];

        public List<RankingEntry> PlayersToday() =>
        [..WholeList.Where(e => e.CreationDate >= DateTime.Today)
                           .OrderByDescending(e => e.Score)];

        public List<RankingEntry> PlayersThisWeek() =>
        [.. WholeList.Where(e => e.CreationDate >= DateTime.Today.AddDays(-7))
                            .OrderByDescending(e => e.Score)];

        public List<RankingEntry> SortedAfterHitScoreInPercentage() =>
        [.. WholeList.OrderByDescending(e => e.HitScoreInPercent),];

        public void GameEvaluation(Round Round)
        {
            MessageBox.Show("Spiel vorbei");

            var userInputInformation = GetInformationFromUserInput();

            RepositoryAddEntry(userInputInformation.User, userInputInformation.CreationDate, Round);
            ShowList(BestUsers(), "Rangliste", true);
        } 

        public void ShowList(List<RankingEntry> list, string titel, bool medals = false)
        {
            using var window = new ListsForm(list, titel, medals);
            window.ShowDialog();
        }

        private void RepositoryAddEntry(string userName, DateTime creationDate, Round Round)
        {
            Add(new RankingEntry
            {
                Username = userName,
                Score = Round.Points,
                HitScoreInPercent = (short)Round.Hitquote,
                Extra = Round.Extra,
                CreationDate = creationDate,
                Difficulty = _settings.CurrentDifficulty
            });
        }
        public string lastEnteredName = "";
        public UsernameWithCreationTimeStampFromUserInput GetInformationFromUserInput()
        {
            string username;
            do
            {
                username = Interaction.InputBox("Gib deine Nutzername ein", "Nutzername", lastEnteredName);
                username = username.Trim();
                username = username.Replace("|", "ಠಿ_ಠ");

                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Bitte einem Nutzername eingeben.");
                }

                if (username.Length > 20)
                {
                    MessageBox.Show("Maximal 20 Zeichen erlaubt.");
                }
            }

            while (string.IsNullOrWhiteSpace(username)
                   || username.Length > 20);

            lastEnteredName = username;
            return new UsernameWithCreationTimeStampFromUserInput(username);
        }

        public void PrepareUserHistoryEntry()
        {
            var userInput = GetInformationFromUserInput();
            var historieFilter = HistorieFilter(userInput.User);

            if (historieFilter.Count == 0)
            {
                MessageBox.Show($"Keine Einträge für {userInput.User} gefunden.");
                return;
            }

            ShowList(historieFilter, $"Historie von {userInput.User}");
        }

        public class UsernameWithCreationTimeStampFromUserInput(string userName)
        {
            internal string User { get; init; } = userName;
            internal DateTime CreationDate { get; init; } = DateTime.Now;
        }
    }
}

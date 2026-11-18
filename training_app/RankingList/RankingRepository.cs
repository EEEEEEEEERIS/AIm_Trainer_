using Aim_Trainer.GameData;
using Microsoft.VisualBasic;
using System.Globalization;

namespace Aim_Trainer.RankingList
{
    public class RankingRepository
    {
        private readonly GameSettings _settings = new();
        private readonly string _listPath;
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
            _listPath = CreateListPath();
        }

        private static string CreateListPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folder = Path.Combine(path, "Spiel");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "Wholeliste.txt");
        }

        private void WriteWholeList()
        {
            try
            {
                //einfügen von | für trennung
                var lines = WholeList.Select(entry =>
                    $"{entry.Username}|" +
                    $"{entry.Score}|" +
                    $"{entry.HitScoreInPercent}%|" +
                    $"{entry.Extra}|" +
                    $"{entry.CreationDate.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)}|" +
                    $"{entry.Difficulty}");
                //schreibt
                File.WriteAllLines(_listPath, lines);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Liste konnte nicht gespeichert werden: " + ex.Message);
            }
        }

        //liest daten wieder ein damit die Rangliste wieder angezeigt werden kann nach schließen
        public void LoadOrCreateWholeList()
        {
            if (!File.Exists(_listPath))
            {
                WholeList = [];
                return;
            }

            try
            {
                //liest ein, splited bei den | wieder
                WholeList = [.. File.ReadAllLines(_listPath)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => line.Split('|'))
                    .Where(parts => parts.Length >= 6)
                    .Select(parts => new RankingEntry
                    {
                        Username = parts[0].Trim(),
                        Score = int.Parse(parts[1].Trim()),
                        HitScoreInPercent = short.Parse(parts[2].Trim().TrimEnd('%')),
                        Extra = parts[3].Trim(),
                        CreationDate = DateTime.ParseExact(
                             parts[4].Trim(),
                            "dd.MM.yyyy HH:mm",
                            CultureInfo.InvariantCulture),
                         Difficulty = Enum.Parse<GameSettings.Difficulty>(parts[5].Trim())
                    })];
            }
            catch (Exception)
            {
                WholeList = [];
            }
        }

        public void RepositoryAddEntry(RankingEntry eintrag)
        {
            WholeList.Add(eintrag);
            WriteWholeList();
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
            RepositoryAddEntry(new RankingEntry
            {
                Username = userName,
                Score = Round.Points,
                HitScoreInPercent = (short)Round.Hitquote,
                Extra = Round.Extra,
                CreationDate = creationDate,
                Difficulty = _settings.CurrentDifficulty
            });
        }

        public void ShowRankingAccordingToDifficulty(GameSettings.Difficulty difficultyLevel)
        {
            var list = BestUserforDifficulties(difficultyLevel);

            if (list.Count == 0)
            {
                MessageBox.Show($"Noch keine Einträge für {difficultyLevel}.");
                return;
            }
            ShowList(BestUserforDifficulties(difficultyLevel), "Rangliste von " + difficultyLevel, true);
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

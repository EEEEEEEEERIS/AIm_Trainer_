using Aim_Trainer.GameData;
using Aim_Trainer.RankingList;

namespace TestProject1
{
    public class WholeListSavingTests : IDisposable
    {
        private readonly string testOrdner;
        private readonly string testDatei;


        public WholeListSavingTests()
        {
            testOrdner = Path.Combine(Path.GetTempPath(), "AimTest_" + Guid.NewGuid());
            Directory.CreateDirectory(testOrdner);
            testDatei = Path.Combine(testOrdner, "rangliste.txt");
        }

        public void Dispose()
        {
            if (Directory.Exists(testOrdner))
            {
                Directory.Delete(testOrdner, true);
            }
        }

        private static RankingEntry NeuerEintrag(string name, int score)
        {
            return new RankingEntry
            {
                Username = name,
                Score = score,
                HitScoreInPercent = 80,
                Extra = "",
                CreationDate = new DateTime(2026, 8, 22, 12, 30, 0),
                Difficulty = GameSettings.Difficulty.Hard
            };
        }

        [Fact]
       public void GespeicherterEintrag_WirdWiederKorrektGeladen()
        {
            // Arrange
            var speicher = new RankingRepository(testDatei);
            speicher.RepositoryAddEntry(NeuerEintrag("gustav", 42));

            // Act – zweites Objekt liest die Datei neu ein
            var neuGeladen = new RankingRepository(testDatei);
            neuGeladen.LoadOrCreateWholeList();

            // Assert
            var eintrag = Assert.Single(neuGeladen.WholeList);
            Assert.Equal("gustav", eintrag.Username);
            Assert.Equal(42, eintrag.Score);
            Assert.Equal(80, eintrag.HitScoreInPercent);
            Assert.Equal(new DateTime(2026, 8, 22, 12, 30, 0), eintrag.CreationDate);
            Assert.Equal(GameSettings.Difficulty.Hard, eintrag.Difficulty);
        }
    }
}
    

namespace _Project.Services.PlayerProgress
{
    public class PersistentProgress : IPersistentProgress
    {
        public Data.CurrentPlayerProgress Progress { get; set; }

        public void IncrementCurrentLevel()
        {
            Progress.CurrentLevel++;
        }
    }
}
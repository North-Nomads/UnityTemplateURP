using System;

namespace _Project.Services.CurrentLevelProgress
{
    public interface ILevelProgress
    {
        event EventHandler WaveCleared;
        event EventHandler LevelCleared;
        event EventHandler PlayerCoreDestroyed;
        LevelConfig LoadedLevelConfig { get; }
        MobWave LoadedWave { get; }
        bool IsLevelSuccessfullyFinished { get; }
        void LoadLevelConfig(LevelConfig levelConfig);
        float GetCurrentWaveTimer();
    }
}
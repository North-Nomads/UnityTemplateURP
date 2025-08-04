using System;
using System.Linq;
using _Project.StaticData;

namespace _Project.Services.CurrentLevelProgress
{
    public class LevelProgress : ILevelProgress
    {
        public event EventHandler WaveCleared = delegate { };
        public event EventHandler LevelCleared = delegate { };
        public event EventHandler PlayerCoreDestroyed = delegate { };

        private readonly IStaticData _staticData;
        private LevelConfig _loadedLevelConfig;
        
        private int _mobsLeftThisWave;
        private int _currentWaveIndex;
        private MobWave _loadedWave;
        private bool _isLastWave;

        public LevelConfig LoadedLevelConfig => _loadedLevelConfig;
        public MobWave LoadedWave => _loadedWave;

        public bool IsLevelSuccessfullyFinished { get; private set; }

        public LevelProgress(IStaticData staticData)
        {
            _staticData = staticData;
        }

        public void LoadLevelConfig(LevelConfig levelConfig)
        {
            IsLevelSuccessfullyFinished = false;
            _loadedLevelConfig = levelConfig;
            _currentWaveIndex = 0;
            _isLastWave = false;
            LoadCurrentWaveConfig();
        }

        public float GetCurrentWaveTimer()
            => _loadedWave.SecondsDelayBeforeWave;

        private void LoadCurrentWaveConfig()
        {
            _loadedWave = _loadedLevelConfig.MobWaves[_currentWaveIndex];
            _mobsLeftThisWave = _loadedWave.Gates.Sum(gate => gate.LevelEnemies.Sum(enemy => enemy.Quantity));
        }
    }
}
using System;
using UnityEngine;

namespace _Project.Services.CurrentLevelProgress
{
    [CreateAssetMenu(fileName = "Level_", menuName = "Config/LevelConfig", order = 2)]
    public class LevelConfig : ScriptableObject
    {
        [Header("=== LEVEL ===")]
        [SerializeField] private int levelID = 0;
        [SerializeField] private int initialMoney = 0;
        [Header("Core/generator parameters")]
        [SerializeField] private int coreHealth;
        [SerializeField] private float generatorCurrentGenerationPerSecond;
        [SerializeField] private float deltaBetweenSpawns;
        [Header("Building options")]
        [SerializeField] private int[] sentryIDs;
        [SerializeField] private int[] buildingIDs;
        [Header("Elements = waves")]
        [SerializeField] private MobWave[] mobWaves;



        public int LevelID => levelID;
        public int InitialMoney => initialMoney;
        public MobWave[] MobWaves => mobWaves;
        public int CoreHealth => coreHealth;
        public int[] SentryIDs => sentryIDs;
        public float GeneratorCapacity => generatorCurrentGenerationPerSecond;
        public float DeltaBetweenSpawns => deltaBetweenSpawns;

        public int[] BuildingIDs => buildingIDs;
    }

    [Serializable]
    public class MobWave
    {
        [SerializeField] private float secondsDelayBeforeWave;
        [SerializeField] private Gate[] gates;

        public Gate[] Gates => gates;
        public float SecondsDelayBeforeWave => secondsDelayBeforeWave;
    }

    [Serializable]
    public class Gate
    {
        [SerializeField] private EnemyEntry[] levelEnemies;

        public EnemyEntry[] LevelEnemies => levelEnemies;
    }

    [Serializable]
    public class EnemyEntry
    {
        [SerializeField] private int quantity;
        [SerializeField] private int enemyID;

        public int Quantity => quantity;
        public int EnemyID => enemyID;
    }
}
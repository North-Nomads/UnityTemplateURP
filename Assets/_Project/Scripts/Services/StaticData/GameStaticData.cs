using System.Collections.Generic;
using UnityEngine;
using _Project.StaticData;

namespace _Project.StaticData
{
    [CreateAssetMenu(fileName = "GameWindows", menuName = "Config/Game window static data", order = 2)]
    public class GameWindowStaticData : ScriptableObject
    {
        public List<GameWindowConfig> Configs;
    }
}
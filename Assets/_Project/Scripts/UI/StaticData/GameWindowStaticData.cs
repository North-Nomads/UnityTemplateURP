using System.Collections.Generic;
using Template._Project.Scripts.Services.StaticData;
using UnityEngine;

namespace Template._Project.Scripts.UI.StaticData
{
    [CreateAssetMenu(fileName = "GameWindowStaticData", menuName = "Configs/UI/GameWindows", order = 1)]
    public class GameWindowStaticData : ScriptableObject
    {
        public List<GameWindowConfig> Configs;
    }
}
using System.Collections.Generic;
using Template._Project.Scripts.Services.StaticData;
using UnityEngine;

namespace Template._Project.Scripts.UI.StaticData
{
    [CreateAssetMenu(fileName = "HubWindowStaticData", menuName = "Configs/UI/HubWindows", order = 2)]
    public class HubWindowStaticData : ScriptableObject
    {
        public List<HubWindowConfig> Configs;
    }
}
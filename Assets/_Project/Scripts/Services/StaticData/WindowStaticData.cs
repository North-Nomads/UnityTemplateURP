using System.Collections.Generic;
using UnityEngine;

namespace _Project.StaticData
{
    [CreateAssetMenu(fileName = "Windows", menuName = "Config/Window static data", order = 1)]
    public class WindowStaticData : ScriptableObject
    {
        public List<HubWindowConfig> Configs;
    }
}
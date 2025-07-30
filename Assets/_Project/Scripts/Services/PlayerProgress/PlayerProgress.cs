using System;

namespace Template._Project.Scripts.Services.PersistentProgress
{
    [Serializable]
    public class PlayerProgress
    {
        private uint _lastFinishedLevel;
        // Level ID, Money between levels, etc as public fields

        public PlayerProgress()
        {
            _lastFinishedLevel = 0;
        }

        public override string ToString()
        {
            return "PlayerProgress: ...";
        }

        public uint LastFinishedLevel => _lastFinishedLevel;
    }
}
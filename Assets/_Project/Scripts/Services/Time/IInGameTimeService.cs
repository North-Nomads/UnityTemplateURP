using System;

namespace Template._Project.Scripts.TimeManagement
{
    public interface IInGameTimeService
    {
        event EventHandler<bool> GamePaused;

        void EnablePause();
        void RestoreTimePassage();
    }
}
using System;

namespace _Project.Infrastructure.InGameTime
{
    public interface IInGameTimeService
    {
        event EventHandler<bool> GamePaused;

        void EnablePause();
        void RestoreTimePassage();
    }
}
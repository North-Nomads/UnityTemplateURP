﻿using _Project.Data;

namespace _Project.Services.PlayerProgress
{
    /// <summary>
    /// Service that provides access to player progress
    /// </summary>
    public interface IPersistentProgress 
    {
        CurrentPlayerProgress Progress { get; set; }
        void IncrementCurrentLevel();
    }
}
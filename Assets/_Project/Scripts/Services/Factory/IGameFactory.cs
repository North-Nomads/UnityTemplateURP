using System.Collections.Generic;
using _Project.Services.PlayerProgress;

namespace _Project.Services.Factory
{
    public interface IGameFactory : IProgressUpdater
    {
        List<ISavedProgressReader> ProgressReaders { get; } 
        List<IProgressUpdater> ProgressWriters { get; }
        void CleanUp();
    }
}
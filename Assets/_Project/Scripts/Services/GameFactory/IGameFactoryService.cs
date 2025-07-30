using System.Collections.Generic;
using Template._Project.Scripts.Services.PersistentProgress;

namespace Template._Project.Scripts.Services.GameFactory
{
    public interface IGameFactoryService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgressReadWriter> ProgressWriters { get; }
    }
}
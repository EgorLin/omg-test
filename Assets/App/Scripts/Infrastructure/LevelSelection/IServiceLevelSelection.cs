using System;

namespace App.Scripts.Infrastructure.LevelSelection
{
    public interface IServiceLevelSelection
    {
        int CurrentLevelIndex { get; }
        int TotalLevelCount { get; }
        event Action OnSelectedLevelChanged;
        void UpdateSelectedLevel(int levelIndex);
    }
}
using System;

namespace App.Scripts.Infrastructure.LevelSelection
{
    public interface IServiceLevelSelection
    {
        int CurrentLevelIndex { get; }
        int TotalLevelCount { get; }
        int PreviousLevelIndex { get; set; }
        event Action OnSelectedLevelChanged;
        void UpdateSelectedLevel(int levelIndex);
    }
}
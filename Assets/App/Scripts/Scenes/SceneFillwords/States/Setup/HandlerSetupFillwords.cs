using App.Scripts.Infrastructure.GameCore.Commands.SwitchLevel;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Infrastructure.LevelSelection;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels.View.ViewGridLetters;
using App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel;
using System;
using System.Threading.Tasks;

namespace App.Scripts.Scenes.SceneFillwords.States.Setup
{
    public class HandlerSetupFillwords : IHandlerSetupLevel
    {
        private readonly ContainerGrid _containerGrid;
        private readonly IProviderFillwordLevel _providerFillwordLevel;
        private readonly IServiceLevelSelection _serviceLevelSelection;
        private readonly ViewGridLetters _viewGridLetters;
        private readonly ICommandSwitchLevel _commandSwitchLevelState;

        public HandlerSetupFillwords(IProviderFillwordLevel providerFillwordLevel,
            IServiceLevelSelection serviceLevelSelection,
            ViewGridLetters viewGridLetters, ContainerGrid containerGrid)
        {
            _providerFillwordLevel = providerFillwordLevel;
            _serviceLevelSelection = serviceLevelSelection;
            _viewGridLetters = viewGridLetters;
            _containerGrid = containerGrid;
            // better to pass through dependencies, but it is forbidden to change the signature
            _commandSwitchLevelState = new CommandSwitchLevelState<StateSetupLevel>(_serviceLevelSelection, new GameStateMachine());
        }

        public Task Process()
        {
            var model = _providerFillwordLevel.LoadModel(_serviceLevelSelection.CurrentLevelIndex);

            while (model is null)
            {
                if (_serviceLevelSelection.CurrentLevelIndex > _serviceLevelSelection.PreviousLevelIndex)
                {
                    if (_serviceLevelSelection.CurrentLevelIndex == _serviceLevelSelection.TotalLevelCount)
                        throw new Exception();
                    _commandSwitchLevelState.Execute(1);
                }
                else
                {
                    _commandSwitchLevelState.Execute(-1);
                }

                model = _providerFillwordLevel.LoadModel(_serviceLevelSelection.CurrentLevelIndex);
            }

            _viewGridLetters.UpdateItems(model);
            _containerGrid.SetupGrid(model, _serviceLevelSelection.CurrentLevelIndex);

            _serviceLevelSelection.PreviousLevelIndex = _serviceLevelSelection.CurrentLevelIndex;

            return Task.CompletedTask;
        }
    }
}
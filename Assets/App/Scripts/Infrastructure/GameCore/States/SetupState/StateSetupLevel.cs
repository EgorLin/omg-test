using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.TaskExtensions;
using System.Threading.Tasks;

namespace App.Scripts.Infrastructure.GameCore.States.SetupState
{
    public class StateSetupLevel : GameState
    {
        private readonly IHandlerSetupLevel _handlerSetup;

        public StateSetupLevel(IHandlerSetupLevel handlerSetupLevels)
        {
            _handlerSetup = handlerSetupLevels;
        }

        public override void OnEnterState()
        {
            ProcessSetupLevel().Forget();
        }

        private async Task ProcessSetupLevel()
        {
            await _handlerSetup.Process();

            StateMachine.ChangeState<StateProcessGame>();
        }
    }
}
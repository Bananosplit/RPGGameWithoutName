namespace Assets.CodeBase.Infrastructure.States {
    public class GameLoopState : IState {
        private StateMachine state;

        public GameLoopState(StateMachine state) {
            this.state = state;
        }

        public void Enter() { }

        public void Exit() { }
    }
}
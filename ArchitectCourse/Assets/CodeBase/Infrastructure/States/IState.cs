namespace Assets.CodeBase.Infrastructure.States {

    public interface IState : IExitableState {
        public void Enter();
    }

    public interface IPayLoadState<TPayLoad> : IExitableState {
        public void Enter(TPayLoad payLoad);
    }

    public interface IExitableState {
        public void Exit();
    }
}
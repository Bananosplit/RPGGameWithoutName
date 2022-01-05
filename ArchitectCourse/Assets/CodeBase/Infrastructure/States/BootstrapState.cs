using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.AllServices.Input;
using Assets.CodeBase.Infrastructure.AssetManagment;
using Assets.CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States {

    public class BootstrapState : IState {

        private readonly StateMachine state;
        private SceneLoader sceneLoader;
        private const string startScene = "initial";
        private const string mainScene = "Main";

        private readonly ServiceLocator services;

        public BootstrapState(StateMachine state, SceneLoader loader, ServiceLocator service) {
            
            this.state = state;
            this.sceneLoader = loader;
            this.services = ServiceLocator.Container;
            RegisterServices();
        }

        public void Enter() {
            sceneLoader.Load(startScene, EnterLoadLevel);
        }

        public void Exit() { }

        private void EnterLoadLevel() => state.Enter<LoadLevelState, string>(mainScene);

        private void RegisterServices() {

            services.RegisterSingle<IAssetProvider>(new AssetProvider());
            services.RegisterSingle<IInputService>(RegisterInputService());
            services.RegisterSingle<IGameFactory>(new GameFactory(
                ServiceLocator.Container.Single<IAssetProvider>()
                ));
        }

        private static IInputService RegisterInputService() {

            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}
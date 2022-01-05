using Assets.CodeBase.Infrastructure.Factory;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure;
using CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States {
    public class LoadLevelState : IPayLoadState<string> {

        private const string startHeroPosition = "InitialPoint";

        private readonly StateMachine state;
        private SceneLoader sceneLoader;
        private LoadingCurtain curtain;

        private IGameFactory gameFactory;

        public LoadLevelState(StateMachine state, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory) {
            this.sceneLoader = sceneLoader;
            this.state = state;
            this.curtain = curtain;
            this.gameFactory = gameFactory;
        }

        public void Enter(string payLoad) {
            curtain.Show();
            sceneLoader.Load(payLoad, OnLoaded);
        }

        public void Exit() => curtain.Hide();

        public void OnLoaded() {

            var hero = gameFactory.CreateHero(GameObject.FindWithTag(startHeroPosition));

            gameFactory.CreateHudSub();

            CameraFollow(hero);

            state.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject gameObject) =>
            Camera.main.GetComponent<CameraFollow>().Follow(gameObject);



    }
}
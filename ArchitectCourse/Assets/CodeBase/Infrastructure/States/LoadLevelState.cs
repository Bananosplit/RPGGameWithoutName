using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using Assets.CodeBase.Infrastructure.Factory;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure;
using CodeBase.Logic;
using System;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States {
    public class LoadLevelState : IPayLoadState<string> {

        private const string startHeroPosition = "InitialPoint";

        private readonly StateMachine state;
        private SceneLoader sceneLoader;
        private LoadingCurtain curtain;

        private IGameFactory gameFactory;
        private readonly IPersistentProgress persistentProgress;

        public LoadLevelState(StateMachine state,
            SceneLoader sceneLoader,
            LoadingCurtain curtain,
            IGameFactory gameFactory,
            IPersistentProgress persistentProgress)
        {

            this.sceneLoader = sceneLoader;
            this.state = state;
            this.curtain = curtain;
            this.gameFactory = gameFactory;
            this.persistentProgress = persistentProgress;
        }

        public void Enter(string payLoad) {
            curtain.Show();
            sceneLoader.Load(payLoad, OnLoaded);
        }

        public void Exit() => curtain.Hide();

        public void OnLoaded() {

            InitGameWorld();
            InformProgressReaders();
            state.Enter<GameLoopState>();
        }

        private void InformProgressReaders() {
            foreach (var progressReader in gameFactory.ProgressReaders)
                progressReader.LoadProgress(persistentProgress.GetProgress());
        }

        private void InitGameWorld()
        {
            GameObject hero = InitHero();
            CreateSubHud(hero);
            CameraFollow(hero);
        }

        private GameObject InitHero()
        {
            return gameFactory.CreateHero(GameObject.FindWithTag(startHeroPosition));
        }

        private void CreateSubHud(GameObject hero)
        {
            GameObject hud = gameFactory.CreateHudSub();
            hud.GetComponentInChildren<ActorUI>().SetHealth(hero.GetComponent<HeroHealth>());
        }

        private void CameraFollow(GameObject gameObject) =>
            Camera.main.GetComponent<CameraFollow>().Follow(gameObject);
    }
}
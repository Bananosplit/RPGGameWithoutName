using Assets.CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure {
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game game;
        public LoadingCurtain CurtainPrefab;

        private void Awake()
        {
            game = new Game(this, Instantiate(CurtainPrefab));
            game.State.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }         
    }
}
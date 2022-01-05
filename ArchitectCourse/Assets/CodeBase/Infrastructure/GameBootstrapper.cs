using Assets.CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure {
    public class GameBootstrapper : MonoBehaviour, ICorutineRunner
    {
        private Game game;
        public LoadingCurtain Curtain;

        private void Awake()
        {
            game = new Game(this, Curtain);
            game.State.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }         
    }
}
using Assets.CodeBase.Infrastructure.AllServices.Input;
using Assets.CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure {
    public class Game
    {
        public static IInputService InputService;
        public StateMachine State;
       
        public Game(ICorutineRunner corutine, LoadingCurtain curtain) {
            State = new StateMachine(new SceneLoader(corutine), curtain);
        }
    }
}
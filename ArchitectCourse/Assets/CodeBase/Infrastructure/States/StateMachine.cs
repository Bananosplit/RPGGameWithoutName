using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure;
using CodeBase.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States {
    public class StateMachine {

        private Dictionary<Type, IExitableState> states;
        private IExitableState currentState;

        public StateMachine(SceneLoader sceneLoader, LoadingCurtain curtain) {
            states = new Dictionary<Type, IExitableState>() {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, ServiceLocator.Container),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain, ServiceLocator.Container.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>() where TState : class, IState {
            TState state = ChangedState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad> {

            TState state = ChangedState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangedState<TState>() where TState : class, IExitableState {

            currentState?.Exit();
            TState state = GetState<TState>();
            currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState {
            return states[typeof(TState)] as TState;
        }
    }
}

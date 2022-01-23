using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.AllServices.LoadService;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Infrastructure.States {
    public class LoadProgressState : IState {

        private readonly StateMachine state;
        private readonly IPersistentProgress progress;
        private readonly ISaveLoadService loadService;


        public LoadProgressState(StateMachine state, IPersistentProgress progress, ISaveLoadService loadService) {
            this.state = state;
            this.progress = progress;
            this.loadService = loadService;
        }

        public void Enter() {
            LoadProgressOrInitNew();
            state.Enter<LoadLevelState, string> (progress.Progress.WorldData.PositionOnLevel.SceneName);
        }

        public void Exit() {
        }

        private void LoadProgressOrInitNew() {
            if (loadService.LoadProgress().WorldData == null)
                progress.Progress = NewProgress();
            else progress.Progress = loadService.LoadProgress();
        }

        private PlayerProgress NewProgress() {
            return new PlayerProgress("Main");
        }
    }
}

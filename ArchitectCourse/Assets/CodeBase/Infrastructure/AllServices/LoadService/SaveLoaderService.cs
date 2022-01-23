using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using Assets.CodeBase.Infrastructure.Factory;

using UnityEngine;

namespace Assets.CodeBase.Infrastructure.AllServices.LoadService {
    class SaveLoaderService : ISaveLoadService {

        private const string KeyString = "Progress";

        private readonly IPersistentProgress playerProgress;
        private readonly IGameFactory gameFactory;

        public SaveLoaderService(IPersistentProgress playerProgress, IGameFactory gameFactory) {
            this.playerProgress = playerProgress;
            this.gameFactory = gameFactory;
        }

        public void SaveProgress() {
            foreach (var progressWriters in gameFactory.ProgressWriters) 
                progressWriters.SaveProgress(playerProgress.Progress);

            PlayerPrefs.SetString(KeyString, playerProgress.Progress.WorldData.ToJson());
            
            PlayerPrefs.Save();
        }

        public PlayerProgress LoadProgress() => new PlayerProgress { WorldData = PlayerPrefs.GetString(KeyString)?.ToDeserialized<WorldData>() };
    }
}

using AssemblyCSharp.Assets.CodeBase.Data;
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
                progressWriters.SaveProgress(playerProgress.GetProgress());

            var progressJson = playerProgress.GetProgress().ToJson();

            PlayerPrefs.SetString(KeyString, progressJson);
            PlayerPrefs.Save();
        }

        public PlayerProgress LoadProgress() {
            PlayerProgress load = PlayerPrefs.GetString(KeyString)?.ToDeserialized<PlayerProgress>();
            return load;
        }
    }
}

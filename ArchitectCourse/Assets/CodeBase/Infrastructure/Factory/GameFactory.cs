using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using Assets.CodeBase.Infrastructure.AssetManagment;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory {
    class GameFactory : IGameFactory {

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameObject HeroGameObject { get; set; }
        public event Action HeroCreated;

        private readonly IAssetProvider assetProvider;


        public GameFactory(IAssetProvider assetProvider) {
            this.assetProvider = assetProvider;
        }

        public GameObject CreateHero(GameObject at) {
            HeroGameObject = InstntiateRegistered(AssetsPath.heroPath, at.transform.position);
            HeroCreated?.Invoke();
            return HeroGameObject;
        }

        public GameObject CreateHudSub() => InstantiateRegistered(AssetsPath.hudSubDisplayPath);


        public void CleanUp() {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstntiateRegistered(string path, Vector3 position) {
            GameObject gameObject = assetProvider.Instantiate(path, position);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private GameObject InstantiateRegistered(string path) {
            GameObject gameObject = assetProvider.Instantiate(path);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject) {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader) {
            if (progressReader is ISavedProgress) ProgressWriters.Add(progressReader);
            ProgressReaders.Add(progressReader);
        }
    }
}

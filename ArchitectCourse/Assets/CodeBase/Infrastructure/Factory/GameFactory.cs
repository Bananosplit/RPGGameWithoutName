using AssemblyCSharp.Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Enemies;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using Assets.CodeBase.Infrastructure.AssetManagment;
using CodeBase.Enemy;
using CodeBase.Logic;
using CodeBase.StaticData;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Infrastructure.Factory {
    class GameFactory : IGameFactory {

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameObject HeroGameObject { get; set; }

        private readonly IAssetProvider assetProvider;
        private readonly IStaticDataService staticData;
        private readonly IRandomServise randomServise;
        private readonly IPersistentProgress persistentProgress; 
        

        public GameFactory(IAssetProvider assetProvider, IStaticDataService staticData, IRandomServise randomServise, IPersistentProgress persistentProgress) {
            this.assetProvider = assetProvider;
            this.staticData = staticData;
            this.randomServise = randomServise;
            this.persistentProgress = persistentProgress;
        }

        public GameObject CreateHero(GameObject at) {
            HeroGameObject = InstntiateRegistered(AssetsPath.heroPath, at.transform.position);
            return HeroGameObject;
        }

        public GameObject CreateHudSub()
        {
            var hud = InstantiateRegistered(AssetsPath.hudSubDisplayPath);

            hud.GetComponentInChildren<LootCounter>()
                .Construct(persistentProgress.GetProgress());

            return hud;
        }

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

        public void Register(ISavedProgressReader progressReader) {
            if (progressReader is ISavedProgress) ProgressWriters.Add(progressReader);
            ProgressReaders.Add(progressReader);
        }

        public GameObject CreateMonster(MonsterTypeId id, Transform parent)
        {
            MonsterStaticData monsterData = staticData.ForMonster(id);
            GameObject monster = UnityEngine.Object.Instantiate(monsterData.Prefab, parent);

            IHealth health = monster.GetComponent<IHealth>();
            health.Current = monsterData.Hp;
            health.Max = monsterData.Hp;

            monster.GetComponent<ActorUI>().SetHealth(health);
            monster.GetComponent<AgentMoveToPlayer>().Construct(HeroGameObject.transform);
            monster.GetComponent<NavMeshAgent>().speed = monsterData.MoveSpeed;

            monster.GetComponent<Attack>().Construct(HeroGameObject.transform);

            Attack attackMonster = monster.GetComponent<Attack>();
            attackMonster.Damage = monsterData.Damage;
            attackMonster.Cleavage = monsterData.Cleavage;
            attackMonster.EffectiveDistance = monsterData.EffectiveDistance;

            monster.GetComponent<AgentRotateToPlayer>()?.Construct(HeroGameObject.transform);

            LootSpawner loot = monster.GetComponentInChildren<LootSpawner>();
            loot.SetLoot(monsterData.MinLoot, monsterData.MaxLoot);
            loot.Consruct(this, randomServise);

            return monster;
        }

        public LootPieace CreateLoot()
        {
            var loot =  InstantiateRegistered(AssetsPath.Loot)
                .GetComponent<LootPieace>();

            loot.Construct(persistentProgress.GetProgress());
            return loot;
        }
    }
}

using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using CodeBase.StaticData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory {
    public interface IGameFactory : IService {

        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        GameObject HeroGameObject { get; }
        void CleanUp();
        GameObject CreateHero(GameObject at);
        GameObject CreateHudSub();
        void Register(ISavedProgressReader reader);
        GameObject CreateMonster(MonsterTypeId lich, Transform transform);
    }
}
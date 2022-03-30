﻿using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory {
    public interface IGameFactory : IService {

        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        public GameObject HeroGameObject { get; }
        event Action HeroCreated; 

        public void CleanUp();
        public GameObject CreateHero(GameObject at);
        public void CreateHudSub();
    }
}
﻿using AssemblyCSharp.Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Data
{

    [Serializable]
    public class PlayerProgress
    {
        public State HeroState;
       // public WorldData WorldData { get; set; }
       public PositionOnLevel Level;

        public PlayerProgress() {}

        public PlayerProgress(string initialLevel) {

      //      WorldData = new WorldData(initialLevel);
            Level = new PositionOnLevel(initialLevel);
            HeroState = new State();
        }
    }
}

using AssemblyCSharp.Assets.CodeBase.Data;
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
        public PositionOnLevel Level;
        public Stats HeroStats;

        public PlayerProgress() {}

        public PlayerProgress(string initialLevel) {
        
            Level = new PositionOnLevel(initialLevel);
            HeroState = new State();
            HeroStats = new Stats();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using UnityEngine;

namespace AssemblyCSharp.Assets.CodeBase.Infrastructure.AllServices
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<MonsterTypeId, MonsterStaticData> monsters;


        public void LoadMonsters() => 
            monsters = Resources.LoadAll<MonsterStaticData>("StaticData/Monsters").
                ToDictionary(x => x.MonsterType, x => x);

        public MonsterStaticData ForMonster(MonsterTypeId id) =>
            monsters.TryGetValue(id, out MonsterStaticData staticData) ? staticData : null;
    }
}

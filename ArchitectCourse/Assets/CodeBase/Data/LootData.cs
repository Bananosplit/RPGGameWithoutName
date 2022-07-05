using System;
using AssemblyCSharp.Assets.CodeBase.Data;

namespace Assets.CodeBase.Data
{
    [Serializable]
    public class LootData
    {
        public int Collected;
        public Action Changed;

        public void Collect(Loot loot )
        {
            Collected += loot.Value;
            Changed?.Invoke();
        }
    }
}
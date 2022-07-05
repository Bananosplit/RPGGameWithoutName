using UnityEngine;

namespace AssemblyCSharp.Assets.CodeBase.Infrastructure.AllServices
{
    public class RandomService : IRandomServise
    {
        public int Next(int minValue, int maxValue) => Random.Range(minValue, maxValue);
    }
}

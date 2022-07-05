using System;
using Assets.CodeBase.Infrastructure.AllServices;

namespace AssemblyCSharp.Assets.CodeBase.Infrastructure.AllServices
{
    public interface IRandomServise : IService
    {
        int Next(int minValue, int maxValue);
    }
}
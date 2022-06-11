using Assets.CodeBase.Infrastructure.AllServices;
using CodeBase.StaticData;

namespace AssemblyCSharp.Assets.CodeBase.Infrastructure.AllServices
{
    public interface IStaticDataService : IService
    {
        void LoadMonsters();
        MonsterStaticData ForMonster(MonsterTypeId id);
    }
}
using Assets.CodeBase.Infrastructure.AllServices;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory {
    public interface IGameFactory : IService {
        public GameObject CreateHero(GameObject at);
        public void CreateHudSub();
    }
}
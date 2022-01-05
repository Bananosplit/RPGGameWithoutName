using Assets.CodeBase.Infrastructure.AssetManagment;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory {
    class GameFactory : IGameFactory {


        private readonly IAssetProvider assetProvider;


        public GameFactory(IAssetProvider assetProvider) {
            this.assetProvider = assetProvider;
        }

        public GameObject CreateHero(GameObject at) => 
            assetProvider.Instantiate(AssetsPath.heroPath, at.transform.position);

        public void CreateHudSub() => assetProvider.Instantiate(AssetsPath.hudSubDisplayPath);
    }
}

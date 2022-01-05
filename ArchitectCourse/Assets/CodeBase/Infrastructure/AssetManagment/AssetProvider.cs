using UnityEngine;

namespace Assets.CodeBase.Infrastructure.AssetManagment {
    class AssetProvider: IAssetProvider {

        public GameObject Instantiate(string path) {
            var prefub = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefub);
        }

        public GameObject Instantiate(string path, Vector3 at) {
            var prefub = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefub, at, Quaternion.identity);
        }
    }
}

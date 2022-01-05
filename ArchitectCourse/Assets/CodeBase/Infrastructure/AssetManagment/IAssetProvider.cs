using Assets.CodeBase.Infrastructure.AllServices;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.AssetManagment {

    public interface IAssetProvider: IService {

        public GameObject Instantiate(string path);
        public GameObject Instantiate(string path, Vector3 at);

    }
}
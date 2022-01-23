
using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.AllServices.LoadService;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    class SaveTrigger: MonoBehaviour
    {
        private ISaveLoadService saveLoad;
        public BoxCollider Collider;

        private void Awake() {
            saveLoad = ServiceLocator.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter(Collider other) {
            saveLoad.SaveProgress();
            Debug.Log("Progress Saved");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos() {
            if (!Collider) return;
            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + Collider.center, Collider.size);
        }

    }
}

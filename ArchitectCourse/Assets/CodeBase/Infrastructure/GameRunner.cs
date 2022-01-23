using CodeBase.Infrastructure;
using System;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    class GameRunner : MonoBehaviour
    {
        public GameBootstrapper GameBootstrapperPrefab;

        private void Awake() {
            var bootsttrapper = FindObjectOfType<GameBootstrapper>();

            if (bootsttrapper == null)
                Instantiate(GameBootstrapperPrefab);
        }

    }
}

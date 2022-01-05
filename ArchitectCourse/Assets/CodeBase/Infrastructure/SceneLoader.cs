using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure {
    public class SceneLoader  {
        private readonly ICorutineRunner corutine;

        public SceneLoader(ICorutineRunner corutine) {
            this.corutine = corutine;
        }

        public void Load(string name, Action onLoaded = null) {
            corutine.StartCoroutine(LoadScene(name, onLoaded));
        }

        private IEnumerator LoadScene(string name, Action onLoaded) {
            if (SceneManager.GetActiveScene().name == name) {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitLoadScene = SceneManager.LoadSceneAsync(name);

            while (!waitLoadScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}
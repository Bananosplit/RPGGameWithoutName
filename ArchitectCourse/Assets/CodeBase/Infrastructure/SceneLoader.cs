using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure {

    public class SceneLoader  {

        private readonly ICoroutineRunner coroutine;

        public SceneLoader(ICoroutineRunner coroutine) {
            this.coroutine = coroutine;
        }

        public void Load(string name, Action onLoaded = null) {
            coroutine.StartCoroutine(LoadScene(name, onLoaded));
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
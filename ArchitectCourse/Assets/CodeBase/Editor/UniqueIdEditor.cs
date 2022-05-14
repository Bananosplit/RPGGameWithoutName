using System;
using System.Linq;
using CodeBase.Logic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var uniqueId = (UniqueId)target;
            
            if(IsPrefab(uniqueId))
                return;
            
            if (string.IsNullOrEmpty(uniqueId.Id))
                Generate(uniqueId);
            else
            {
                UniqueId[] uniqueIds = FindObjectsOfType<UniqueId>();
                if(uniqueIds.Any(other => other != uniqueId && other.Id == uniqueId.Id))
                    Generate(uniqueId);
            }
        }

        private bool IsPrefab(UniqueId uniqueId) => 
            uniqueId.gameObject.scene.rootCount == 0;

        private void Generate(UniqueId uniqueId)
        {
            //generate id with unity
            uniqueId.Id = $"{uniqueId.gameObject.scene.name}_{Guid.NewGuid().ToString()}";

            if (!Application.isPlaying)
            {
            //сообщает юнити, об изменении объекта из кода
            EditorUtility.SetDirty(uniqueId);
            
            //Мы меняем объект на сцене, надо сказать, чтобы она и объекты пересохранила
            EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
            }
            //мы собираемся сделать как юнити, чтобы при изменении сцены в плеймоде
            //чтобы все изменения откатывались назад, сделаем проверку

        }
    }
}
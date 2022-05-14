using System;
using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using CodeBase.Logic;
using CodeBase.StaticData;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISavedProgressReader
{
 public MonsterTypeId monsterId;
 
 private string id;
 public bool Slain;
 

 private void Awake()
 {
  id = GetComponent<UniqueId>().Id;
 }

 public void SaveProgress(PlayerProgress progress)
 {
  if(Slain)
   progress.KillData.ClearedSpawners.Add(id);
 }

 public void LoadProgress(PlayerProgress progress)
 {
  if (progress.KillData.ClearedSpawners.Contains(id))
   Slain = true;
  else
   Spawn();
 }

 private void Spawn()
 {
 }
}


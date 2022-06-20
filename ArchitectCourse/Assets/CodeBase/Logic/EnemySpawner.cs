using System;
using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using Assets.CodeBase.Infrastructure.Factory;
using CodeBase.Logic;
using CodeBase.StaticData;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISavedProgressReader
{
    public MonsterTypeId monsterId;

    private string id;
    public bool Slain { get; private set; }
    private IGameFactory gameFactory;
    private EnemyDeath enemyDeath;

    private void Awake()
    {
        id = GetComponent<UniqueId>().Id;
        gameFactory = ServiceLocator.Container.Single<IGameFactory>();
    }

    public void SaveProgress(PlayerProgress progress)
    {
        if (Slain)
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
        GameObject monster = gameFactory.CreateMonster(monsterId, transform);
        enemyDeath = monster.GetComponent<EnemyDeath>();
        enemyDeath.Happened += Slay;
    }

    private void Slay()
    {
        if (enemyDeath != null)
            enemyDeath.Happened -= Slay;

        Slain = true;
    }

}


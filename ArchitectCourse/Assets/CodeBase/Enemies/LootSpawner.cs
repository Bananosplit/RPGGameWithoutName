using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.CodeBase.Data;
using AssemblyCSharp.Assets.CodeBase.Infrastructure.AllServices;
using Assets.CodeBase.Infrastructure.Factory;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public EnemyDeath EnemyDeath;
    private IGameFactory factory;
    private IRandomServise randomService;

    private int lootMin;
    private int lootMax;

    public void Consruct(IGameFactory factory, IRandomServise random)
    {
        this.factory = factory;
        randomService = random;
    }

    void Start()
    {
        EnemyDeath.Happened += SpawnLoot;
    }

    private void SpawnLoot()
    {
        LootPieace loot = factory.CreateLoot();
        loot.transform.position = transform.position;
        Loot lootItem = GenerateLoot();

        loot.Initialize(lootItem);
    }

    private Loot GenerateLoot()
    {
        return new Loot()
        {
            Value = randomService.Next(lootMin, lootMax)
        };
    }

    public void SetLoot(int min, int max) {
        this.lootMin = min;
        this.lootMax = max;
      }
}

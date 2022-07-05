using System;
using System.Collections;
using System.Collections.Generic;
using Assets.CodeBase.Data;
using TMPro;
using UnityEngine;

public class LootCounter : MonoBehaviour
{
    public TextMeshProUGUI Counter;

    private PlayerProgress _worldData;

    public void Start() => UpdateCouner();

    public void Construct(PlayerProgress worldData)
    {
        _worldData = worldData;
        worldData.LootData.Changed += UpdateCouner;
    }

    private void UpdateCouner() => 
        Counter.text = $"{_worldData.LootData.Collected}";
}

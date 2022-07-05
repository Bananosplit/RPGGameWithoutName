using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.CodeBase.Data;
using Assets.CodeBase.Data;
using TMPro;
using UnityEngine;

public class LootPieace : MonoBehaviour
{
    public GameObject Scull;
    public GameObject PickupFXPrefub;
    public TextMeshPro LootText;
    public GameObject PickupPopup;

    private Loot lootItem;
    private bool picked;
    private PlayerProgress playerProgress;

    public void Construct(PlayerProgress playerProgress)
    {
        this.playerProgress = playerProgress;
    }

    public void Initialize(Loot loot)
    {
        lootItem = loot;
    }

    void OnTriggerEnter(Collider other) => Pickup();

    private void Pickup()
    {
        if (picked)
            return;

        picked = true;

        UpdatePlayerProgress();
        HideScull();
        TextPopup();
  //      PlayFXPickup();
        StartCoroutine(DestroyGameObjectTimer());
    }

    private void UpdatePlayerProgress()
    {
        playerProgress.LootData.Collect(lootItem);
    }

    private void HideScull()
    {
        Scull.SetActive(false);
    }

    private IEnumerator DestroyGameObjectTimer()
    { 
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    private void PlayFXPickup()
    {
        Instantiate(PickupFXPrefub, transform.position, Quaternion.identity);
    }

    private void TextPopup()
    {
        LootText.text = $"{lootItem.Value}";
        PickupPopup.SetActive(true);
    }
}

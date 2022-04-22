using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorUI : MonoBehaviour
{
    public HPBar Hpbar;
    private HeroHealth HeroHealth;

    private void OnDestroy()
    {
        HeroHealth.HealthChanged -= UpdateHPbar;
    }

    public void SetHealth(HeroHealth health)
    {
        HeroHealth = health;
        HeroHealth.HealthChanged += UpdateHPbar;
    }

    public void UpdateHPbar()
    {
        Hpbar.SetValue(HeroHealth.Current, HeroHealth.Max);
    }
}
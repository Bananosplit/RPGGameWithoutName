using CodeBase.Logic;
using UnityEngine;

public class ActorUI : MonoBehaviour
{
    public HPBar Hpbar;
    private IHealth Health;

    public void SetHealth(IHealth health)
    {
        Health = health;
        Health.HealthChanged += UpdateHPbar;
    }
    private void Start()
    {
        IHealth _health = GetComponent<IHealth>();

        if (_health != null)
            SetHealth(_health);
    }

    private void OnDestroy()
    {
        if(Health != null)
        Health.HealthChanged -= UpdateHPbar;
    }


    private void UpdateHPbar()
    {
        Hpbar.SetValue(Health.Current, Health.Max);
    }
}
using System;
using Assets.CodeBase.Infrastructure.AllServices;

namespace CodeBase.Logic{
    public interface IHealth {

        float Current { get; set; }
        float Max { get; set; }          
        event Action HealthChanged;
        void TakeDamage(float damage);
    }
}
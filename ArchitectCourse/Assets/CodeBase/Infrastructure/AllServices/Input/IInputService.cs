using Assets.CodeBase.Infrastructure.AllServices;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.AllServices.Input {
    public interface IInputService : IService {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}
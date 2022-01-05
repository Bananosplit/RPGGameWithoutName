using UnityEngine;

namespace Assets.CodeBase.Infrastructure.AllServices.Input {
    public class MobileInputService : InputService {
        public override Vector2 Axis => SimpleInputAxis();
    }
}
using System;
namespace Assets.CodeBase.Data {

    [Serializable]
    public class PositionOnLevel {
        
        public Vector3Data Position;
        public string SceneName;

        public PositionOnLevel(string sceneName) {
            SceneName = sceneName;
        }

        public PositionOnLevel(Vector3Data position, string sceneName) {
            Position = position;
            SceneName = sceneName;
        }

    }
}
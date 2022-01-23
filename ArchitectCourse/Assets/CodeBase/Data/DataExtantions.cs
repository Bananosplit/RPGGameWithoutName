using Assets.CodeBase.Infrastructure.AllServices.PersistentProgress;
using System;
using UnityEngine;


namespace Assets.CodeBase.Data {

    [Serializable]
    static class DataExtantions {
        public static Vector3Data AsVectorData(this Vector3 position) =>
            new Vector3Data(position.x, position.y, position.z);

        public static Vector3 AsUnityVector3(this Vector3Data pos) => new Vector3(pos.X, pos.Y, pos.Z);

        public static T ToDeserialized<T>(this string json) => JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) => JsonUtility.ToJson(obj);
        //public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);

        public static Vector3 AddY(this Vector3 vector, float y) {
            vector.y += y;
            return vector;
        }
    }
}

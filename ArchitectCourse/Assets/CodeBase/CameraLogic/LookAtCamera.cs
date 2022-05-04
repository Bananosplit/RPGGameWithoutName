using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start() => mainCamera = Camera.main;

    void Update()
    {
        Quaternion rotation = mainCamera.transform.rotation;
        transform.LookAt(
            transform.position + rotation * Vector3.back,
            rotation * Vector3.up);
    }
}

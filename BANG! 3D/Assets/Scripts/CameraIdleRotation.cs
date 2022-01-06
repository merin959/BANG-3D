using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIdleRotation : MonoBehaviour
{
    private bool w;
    private const float ROTATION_SPEED = 0.02f;

    void Start()
    {
        w = new System.Random().Next(2) == 0 ? true : false;
    }

    void Update()
    {
        if (transform.eulerAngles.y < 308.5f) w = false;
        if (transform.eulerAngles.y > 321f) w = true;
        transform.eulerAngles = transform.eulerAngles - new Vector3(0, w ? ROTATION_SPEED : -ROTATION_SPEED, 0);
    }
}

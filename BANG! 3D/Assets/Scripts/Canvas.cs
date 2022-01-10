using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public static Canvas instance;

    private void Awake()
    {
        instance = this;
    }
}

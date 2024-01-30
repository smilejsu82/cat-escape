using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 2;
    [SerializeField] private float attenuation = 0.96f;
    private float speed = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Down!");
            speed = maxSpeed;
        }

        this.transform.Rotate(0, 0, speed);
        speed *= attenuation;
    }
}

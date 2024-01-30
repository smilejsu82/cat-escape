using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        this.transform.Translate(Vector3.up * 1 * Time.deltaTime, Space.World);
    }
}

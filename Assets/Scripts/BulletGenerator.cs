using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    public GameObject CreateBullet()
    {
        return Instantiate(this.bulletPrefab);
    }
}

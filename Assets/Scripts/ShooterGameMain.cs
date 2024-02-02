using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ShooterGameMain : MonoBehaviour
{
    [SerializeField] private ExplosionGenerator explosionGenerator;

    [SerializeField] private SpaceShipController spaceShipController;


    private void Start()
    {
        this.spaceShipController.onShoot = (bullet) => {
            bullet.onTrigger = (pos) => {
                this.CreateExplosion(pos);
            };
        };
    }

    private void CreateExplosion(Vector3 pos) {
        GameObject explosionGo = this.explosionGenerator.CreateExplosion();
        explosionGo.transform.position = pos;
        explosionGo.GetComponent<ExplosionController>().Explode();
    }
}

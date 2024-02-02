using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector2 horizontalBoundary;
    [SerializeField] private Vector2 verticalBoundary;
    [SerializeField] private Transform firePoint;
    [SerializeField] private BulletGenerator bulletGenerator;

    public System.Action<BulletController> onShoot;

    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        this.transform.Translate(dir.normalized * this.speed * Time.deltaTime);

        var clampX = Mathf.Clamp(this.transform.position.x, this.horizontalBoundary.x, this.horizontalBoundary.y);
        var clampY = Mathf.Clamp(this.transform.position.y, this.verticalBoundary.x, this.verticalBoundary.y);
        this.transform.position = new Vector2(clampX, clampY);

        //ÃÑ¾Ë¹ß»ç 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletGo = this.bulletGenerator.CreateBullet();
            bulletGo.transform.position = this.firePoint.position;
            this.onShoot(bulletGo.GetComponent<BulletController>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.LogFormat("=> {0}", collision);
            Destroy(this.gameObject);
        }
    }
}

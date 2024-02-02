using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public System.Action<Vector3> onTrigger;

    void Update()
    {
        this.transform.Translate(Vector2.up * this.speed * Time.deltaTime);

        if(this.transform.position.y > 6.56f){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //적에게 피해를 줌 
            Debug.LogFormat("=> {0}", collision);
            this.onTrigger(collision.gameObject.transform.position);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

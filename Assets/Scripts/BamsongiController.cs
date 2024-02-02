using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    private Rigidbody rbody;
    private ParticleSystem particleSystem;
    void Start()
    {
        this.rbody = this.GetComponent<Rigidbody>();
        this.particleSystem = this.GetComponent<ParticleSystem>();
        this.Shoot();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("OnCollisionEnter: {0}", collision.gameObject.name);
        this.rbody.isKinematic = true;

        //파티클시스템 컴포넌트 접근해서 Play메서드 호출 
        this.particleSystem.Play();
    }

    public void Shoot()
    {
        this.rbody.AddForce(new Vector3(0, 200, 2000));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private float duration;

    public void Explode() {
        StartCoroutine(this.CoExplode());
    }

    private IEnumerator CoExplode() {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);
    }
}

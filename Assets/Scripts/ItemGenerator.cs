using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject bombPrefab;
    private float delta = 0f;
    private float span = 2f;

    private void Start()
    {
    }

    void Update()
    {
        delta += Time.deltaTime;
        if (delta >= span) {
            this.CreateItem();
            delta = 0;
        }
    }

    private void CreateItem()
    {
        int rand = Random.Range(0, 2);  //0 ~ 1
        GameObject item = null;
        if (rand == 0) {
            item = Instantiate(this.applePrefab);
        } else if (rand == 1) {
            item = Instantiate(this.bombPrefab);
        }

        float randX = Random.Range(-1.5f, 1.5f);
        var x = Mathf.RoundToInt(randX);

        float randZ = Random.Range(-1.5f, 1.5f);
        var z = Mathf.RoundToInt(randZ);

        item.transform.position = new Vector3(x, 3, z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour

{ 
    public float spawnTimer;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            GameObject go = Instantiate(enemy, new Vector3(Random.Range(-4, 4), 12, 0), Quaternion.identity);
            spawnTimer = 4;
        }
    }
}

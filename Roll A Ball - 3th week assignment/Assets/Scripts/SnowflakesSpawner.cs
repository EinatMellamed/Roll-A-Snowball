using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakesSpawner : MonoBehaviour
{
    [SerializeField] GameObject snowflakePickUp;
    Vector3 spawnPoint;
   [SerializeField] float maxX;
   [SerializeField] float minX;
   [SerializeField] float maxZ;
   [SerializeField] float minZ;
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("SpawnSnowflake", 5f, 5f);
    }

    private void SpawnSnowflake()
    {
        float x = Random.Range(maxX, minX);
        float z = Random.Range(maxZ, minZ);

        spawnPoint = new Vector3(x, 10, z);
       GameObject snowFlake = Instantiate(snowflakePickUp, spawnPoint, transform.rotation);

        Destroy(snowFlake, 5f);

    }
}

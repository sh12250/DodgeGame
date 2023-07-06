using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletSpawner : MonoBehaviour
{
    public Transform bulletPool = default;
    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerControler>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(spawnRate <= timeAfterSpawn)
        {
            timeAfterSpawn = 0;
            transform.LookAt(target);

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation, bulletPool);
            //bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}

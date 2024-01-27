using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrap : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnLocation;
    public Quaternion spawnRotation;

    public float spawnTime = 0.5f;
    public float timeSinceSpawned = 0f;

    public DetectionZone detectionZone;

    private void Start()
    {

    }

    private void Update()
    {
        if (detectionZone.detectObjs.Count > 0)
        {
            timeSinceSpawned += Time.deltaTime;

            if (timeSinceSpawned >= spawnTime)
            {
                Instantiate(projectile, spawnLocation.position, spawnRotation);
                timeSinceSpawned = 0;
            }
        }
        else
        {
            timeSinceSpawned = 0;
        }
    }
}

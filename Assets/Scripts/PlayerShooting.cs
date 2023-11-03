using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBuller;
    [SerializeField] private Transform basicShootPoint;

    [SerializeField] private float shootingInterval;
    private float intervalReset;
    void Start()
    {
        intervalReset = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if(shootingInterval <= 0 )
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    private void Shoot()
    {
        Instantiate(laserBuller, basicShootPoint.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float fireRate = 5;
    public GameObject bullet;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", fireRate, fireRate);
    }
    void Fire()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }

}

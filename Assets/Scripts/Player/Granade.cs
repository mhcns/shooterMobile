using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

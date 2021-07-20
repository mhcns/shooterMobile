using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public int damage = 10;
    private Rigidbody rb;
    private Damager damager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damager = GetComponent<Damager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if(health != null)
        {
            damager.DoDamage(health, damage);
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damage = 10;
    public bool ignoreTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (ignoreTrigger) return;
        Health health = other.GetComponent<Health>();
        if(health != null)
        {
            DoDamage(health, damage);
        }
    }
    public void DoDamage(Health health, int damage)
    {
        health.TakeDamage(damage, transform.position);
    }
}

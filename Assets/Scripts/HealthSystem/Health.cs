using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    protected bool isDead;

    protected abstract void Spawn();
    protected abstract void Death();

    public abstract void TakeDamage(int damage, Vector3 hitPoint);
}

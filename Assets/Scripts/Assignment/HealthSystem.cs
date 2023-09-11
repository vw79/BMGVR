using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float health;

    [SerializeField] private UnityEvent OnHurt;
    [SerializeField] private UnityEvent OnDeath;

    private void Start()
    {
        health = maxHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            OnDeath.Invoke();
            return;
        }

        OnHurt.Invoke();
    }

    public float GetHealth()
    {
        return health;
    }
}

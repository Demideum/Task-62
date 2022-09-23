using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth = 100;
    private float _minHealth = 0;

    public event UnityAction ChangedHealth;
    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public void TakeDamage ()
    {
        float damage = 10;

        if (_health > 0)
        {
            _health -= Mathf.Clamp(damage, _minHealth, _maxHealth);
        }
        ChangedHealth?.Invoke();
    }

    public void TakeHeal()
    {
        float heal = 10;

        if (_health < _maxHealth)
        {
            _health += Mathf.Clamp(heal, _minHealth, _maxHealth);
        }
        ChangedHealth?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] private float _currentHealth;

    private float _maxHealth = 100;
    private float _minHealth = 0;

    public event UnityAction ChangedHealth;
    public float Health => _currentHealth;
    public float MaxHealth => _maxHealth;

    public void TakeDamage ()
    {
        float damage = 10;
       
        if (_currentHealth > 0)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);
        }
        ChangedHealth?.Invoke();
    }

    public void TakeHeal()
    {
        float heal = 10;
        
        if (_currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + heal, _minHealth, _maxHealth);
        }
        ChangedHealth?.Invoke();
    }
}

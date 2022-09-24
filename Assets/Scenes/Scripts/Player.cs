using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] private float _currentHealth;

    private float _maxHealth = 100;
    private float _unitHealth = 1;
    private float _targetHealth;

    public event UnityAction ChangedHealth;
    public float Health => _currentHealth;
    public float MaxHealth => _maxHealth;

    public void TakeDamage ()
    {
        float damage = 10;
        _targetHealth = _unitHealth * damage;

        if (_currentHealth > 0)
        {
            _currentHealth -= Mathf.Clamp(_targetHealth, _targetHealth, _currentHealth);
        }
        ChangedHealth?.Invoke();
    }

    public void TakeHeal()
    {
        float heal = 10;
        _targetHealth = _unitHealth * heal;

        if (_currentHealth < _maxHealth)
        {
            _currentHealth += Mathf.Clamp(_targetHealth, _targetHealth, _currentHealth);
        }
        ChangedHealth?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _imageFillHealthBar;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ChangedHealth += OnChangingHealth;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnChangingHealth;
    }

    private void OnChangingHealth()
    {
        float target = _player.Health / _player.MaxHealth;
        _imageFillHealthBar.DOFillAmount(target, _imageFillHealthBar.fillAmount);
    }
}

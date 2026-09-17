using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar
{
    [SerializeField] private GameObject _healthbar;
    private float _healthBarWidth, _healthBarHeight;

    public HealthBar()
    {
        _healthBarWidth = _healthbar.GetComponent<RectTransform>().sizeDelta.x;
        _healthBarHeight = _healthbar.GetComponent<RectTransform>().sizeDelta.y;
    }

    public void UpdateHealthBaar(float newHealth, float maxHealth)
    {
        _healthbar.GetComponent<RectTransform>().sizeDelta = new Vector2(newHealth / maxHealth * _healthBarWidth, _healthBarHeight);
    }

    public void DeActivateHealthBar()
    {
        _healthbar.SetActive(false);
    }
}

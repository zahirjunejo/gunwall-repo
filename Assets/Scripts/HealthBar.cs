using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar
{
    private GameObject _healthbar;
    private RectTransform  _healthbarRectTransform;
    private float _healthBarWidth, _healthBarHeight;

    public HealthBar(GameObject healthbar)
    {
        _healthbar = healthbar;
        _healthbarRectTransform = _healthbar.GetComponent<RectTransform>();
        _healthBarWidth = _healthbarRectTransform.sizeDelta.x;
        _healthBarHeight = _healthbarRectTransform.sizeDelta.y;
    }

    public void UpdateHealthBar(float newHealth, float maxHealth)
    {
        _healthbarRectTransform.sizeDelta = new Vector2(newHealth / maxHealth * _healthBarWidth, _healthBarHeight);
    }

    public void DeActivateHealthBar()
    {
        _healthbar.SetActive(false);
    }
}

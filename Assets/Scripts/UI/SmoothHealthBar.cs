using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private float _valueChangeSpeed = 0.3f;
    [SerializeField] private Health _health;

    private Slider _healthBar;

    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += SetHealth;
    }

    private void SetHealth()
    {
        float value = _health.CurrentHealth / _health.MaxHealth;

        StartCoroutine(SmoothChangeValue(value));
        StopCoroutine(SmoothChangeValue(value));
    }

    private IEnumerator SmoothChangeValue(float value)
    {
        float startValue = _healthBar.value;
        float targetValue = value;

        while (_healthBar.value != targetValue)
        {
            _healthBar.value = Mathf.MoveTowards(startValue, targetValue, _valueChangeSpeed * Time.deltaTime);
            startValue = _healthBar.value;

            yield return null;
        }
    }

    private void OnDisable()
    {
        _health.HealthChanged -= SetHealth;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
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

    private void OnDisable()
    {
        _health.HealthChanged -= SetHealth;
    }

    private void SetHealth()
    {
        _healthBar.value = _health.CurrentHealth / _health.MaxHealth;
    }
}
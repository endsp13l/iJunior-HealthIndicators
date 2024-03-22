using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        SetHealth();
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
        _text.text = $"Health: {_health.CurrentHealth} / {_health.MaxHealth}";
    }
}
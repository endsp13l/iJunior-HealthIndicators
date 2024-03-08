using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("HealthStats")] 
    [SerializeField] private float _currentHealth = 100f;
    [SerializeField] private float _maxHealth = 100f;
    [Header("HealthIndicators")]
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private SmoothHealthBar _smoothHealthBar;

    private void Start()
    {
        _smoothHealthBar.SetMaxHealth(_maxHealth);
        _currentHealth = _maxHealth;
    }
    
    private void Update()
    {
        _healthText.text = $"Health: {_currentHealth} / {_maxHealth}";
        _healthBar.value = _currentHealth / _maxHealth;
        //_smoothHealthBar.SetHealth(_currentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;

        _smoothHealthBar.SetHealth(_currentHealth);
    }

    public void Heal(float value)
    {
        _currentHealth += value;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        
        _smoothHealthBar.SetHealth(_currentHealth);
    }
}

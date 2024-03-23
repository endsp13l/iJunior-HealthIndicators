using UnityEngine.UI;

public class HealthBar : HealthIndicator
{
   private Slider _healthBar;

    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
    }

    protected override void SetHealth()
    {
        _healthBar.value = _health.CurrentHealth / _health.MaxHealth;
    }
}
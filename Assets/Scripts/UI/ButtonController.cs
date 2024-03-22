using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _healButton;
    [SerializeField] private Button _damageButton;

    private float _healValue = 10f;
    private float _damageValue = 15f;

    private void OnEnable()
    {
        _healButton.onClick.AddListener(Heal);
        _damageButton.onClick.AddListener(Damage);
    }

    private void OnDisable()
    {
        _healButton.onClick.RemoveListener(Heal);
        _damageButton.onClick.RemoveListener(Damage);
    }

    private void Heal()
    {
        _health.Heal(_healValue);
    }

    private void Damage()
    {
        _health.TakeDamage(_damageValue);
    }
}
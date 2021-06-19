using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _healthChenged;

    private float _health = 100;
    private float _damage = 10;
    private float _healing = 10;
    private float _maxHealth = 100;
    private float _minHealth = 0;

    public float Health => _health;

    public void TakeDamage()
    {
        if (_health > _minHealth)
        {
            _health -= _damage;
            _healthChenged?.Invoke();
        }
        else
        {
            _health = _minHealth;
        }
    }

    public void Heal()
    {
        if (_health < _maxHealth)
        {
            _health += _healing;
            _healthChenged?.Invoke();
        }
        else
        {
            _health = _maxHealth;
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _speedChengeHealth;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _healthCount;

    private float _targetHealth;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _player.Health;
        _slider.value = _currentHealth;
        _healthCount.text = _currentHealth.ToString();
    }

    public void ChangeHealthBar()
    {
        _healthCount.text = _player.Health.ToString();
        _targetHealth = _player.Health;
        StartCoroutine("ChangeHealth");
    }

    private IEnumerator ChangeHealth()
    {
        while (_currentHealth != _targetHealth)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _targetHealth, _speedChengeHealth * Time.deltaTime);
            _slider.value = _currentHealth;
            yield return null;
        }
    }
}

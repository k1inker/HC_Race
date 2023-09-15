using System;
using UnityEngine;

public class PlayerStats : Singelton<PlayerStats>
{

    [Header("Stats")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _speedMultiplier = 0f;
    [SerializeField] private bool _invulnerable;
    private float _currentHealth;

    public int Score { get; private set; } = 0;
    public float Speed { get { return _speed * _speedMultiplier; } }
    public bool Invulnerable { get { return _invulnerable; } }

    public Action<float> OnTakeDamage;
    public Action OnDeath;
    public Action<bool> OnTakeMagnet;
    protected override void Awake()
    {
        base.Awake();
        _currentHealth = _maxHealth;
        ManagerUI.Instance.SetMaxHealth(_maxHealth);
        ManagerUI.Instance.SetHealth(_currentHealth);
    }
    private void OnEnable()
    {
        ManagerUI.Instance.OnStartRace += () => _speedMultiplier = 1f;
    }
    public void AddSpeedMultiplier(float multiplier)
    {
        _speedMultiplier += multiplier;
    }
    public void SetInvulnerable(bool isInvulnerable)
    {
        _invulnerable = isInvulnerable;
    }
    public void TakeDamage(float amount, bool isDeadly = false)
    {
        if (_invulnerable)
            return;

        OnTakeDamage?.Invoke(amount);
        _currentHealth -= amount;

        if(_currentHealth <= 0 || isDeadly == true)
        {
            _speed = 0;
            _currentHealth = 0;
            OnDeath?.Invoke();
        }

        ManagerUI.Instance.SetHealth(_currentHealth);
    }
    public void RestoreHealth(float amount)
    {
        _currentHealth += amount;

        _currentHealth = _currentHealth > _maxHealth ? _maxHealth : _currentHealth;
        ManagerUI.Instance.SetHealth(_currentHealth);
    }
    public void IncreaseScore(int amount)
    {
        Score += amount;
        ManagerUI.Instance.SetScore(Score);
    }
}

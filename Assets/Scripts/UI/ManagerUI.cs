using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : Singelton<ManagerUI>
{
    public Action<int> OnHorizontalMovement;
    public Action<int> OnVerticalMovement;

    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _scoreText;

    [Header("References Health")]
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _damageDisplayTime;
    [SerializeField] private Sprite _damageBackgroundSlider;
    [SerializeField] private Image _healthBackgroundSlider;
    [SerializeField] private GameObject _damageBackground;

    [Header("References Booster Slider")]
    [SerializeField] private Slider _boosterSlider;
    [SerializeField] private Image _imageSlider;
    [SerializeField] private Image _backgroundSlider;
    [SerializeField] private TextMeshProUGUI _textBooster;
    private void OnEnable()
    {
        PlayerStats.Instance.OnDeath += EnableDeathScreen;
        PlayerStats.Instance.OnTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        PlayerStats.Instance.OnDeath -= EnableDeathScreen;
        PlayerStats.Instance.OnTakeDamage -= TakeDamage;
    }
    private void EnableDeathScreen()
    {
        _resultPanel.SetActive(true);
    }
    private void TakeDamage(float amount)
    {
        SetHealth(amount);

        StartCoroutine(DisplayDamage());
    }
    public void SetVerticalMove(int direction)
    {
        OnVerticalMovement?.Invoke(direction);
    }
    public void SetupBooster(TemporaryBooster booster)
    {
        // set color duration slider booster
        _boosterSlider.maxValue = booster.duration;
        SetBooster(booster.duration);

        _imageSlider.sprite = booster.imgSlider;
        //_backgroundSlider.sprite = booster.backgroundSlider;

        _textBooster.text = booster.nameBooster;

        _boosterSlider.gameObject.SetActive(true);
    }
    public void SetBooster(float value)
    {
        _boosterSlider.value = value;
    }
    public void SetMaxHealth(float value)
    {
        _healthSlider.maxValue = value;
    }
    public void SetHealth(float value)
    {
        _healthSlider.value = value;
    }
    public void DisableBooster()
    {
        _boosterSlider.gameObject.SetActive(false);
    }
    public void SetScore(int score)
    {
        _scoreText.text = $"Score:\n{score.ToString("N0")}";
    }
    private IEnumerator DisplayDamage()
    {
        //Sprite bufferSprite = _healthBackgroundSlider.sprite;
        //Color bufferColor = _healthBackgroundSlider.color;

        //_healthBackgroundSlider.sprite = _damageBackgroundSlider;
        //_healthBackgroundSlider.color = Color.red;
        _damageBackground.SetActive(true);

        yield return new WaitForSeconds(_damageDisplayTime);

        //_healthBackgroundSlider.sprite = bufferSprite;
        //_healthBackgroundSlider.color = bufferColor;

        _damageBackground.SetActive(false);
    }
}
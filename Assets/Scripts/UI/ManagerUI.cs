using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : Singelton<ManagerUI>
{
    public Action<int> OnHorizontalMovement;
    public Action<int> OnVerticalMovement;

    [Header("References Booster Slider")]
    [SerializeField] private Slider _boosterSlider;
    [SerializeField] private Image _imageSlider;
    [SerializeField] private Image _backgroundSlider;
    [SerializeField] private TextMeshProUGUI _textBooster;
    public void SetVerticalMove(int direction)
    {
        OnVerticalMovement?.Invoke(direction);
    }
    // set color duration slider booster
    public void SetupBooster(TemporaryBooster booster)
    {
        _boosterSlider.maxValue = booster.duration;
        SetValueBooster(booster.duration);

        _imageSlider.sprite = booster.imgSlider;
        _backgroundSlider.sprite = booster.backgroundSlider;

        _textBooster.text = booster.nameBooster;

        _boosterSlider.gameObject.SetActive(true);
    }
    public void SetValueBooster(float value)
    {
        _boosterSlider.value = value;
    }
    public void DisableBooster()
    {
        _boosterSlider.gameObject.SetActive(false);
    }
}
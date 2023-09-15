using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerUI : Singelton<ManagerUI>
{
    public Action<int> OnHorizontalMovement;
    public Action<int> OnVerticalMovement;
    public Action OnStartRace;
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _scoreInGameText;

    [Header("ResultPanel")]
    [SerializeField] private TextMeshProUGUI _myScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    [Header("Counter settings")]
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private int _countDownTime;

    [Header("References Health")]
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _damageDisplayTime;
    [SerializeField] private GameObject _damageBackground;

    [Header("References Booster Slider")]
    [SerializeField] private Slider _boosterSlider;
    [SerializeField] private Image _imageSlider;
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
    private void Start()
    {
        StartCoroutine(StartCountdown());
    }
    private void EnableDeathScreen()
    {
        _resultPanel.SetActive(true);

        int bestScore = SaveSystem.LoadScore();
        int selfScore = PlayerStats.Instance.Score;

        _myScoreText.text = $"Your score:\n{selfScore.ToString("N0")}";
        if (bestScore < selfScore)
        {
            _bestScoreText.text = $"Best score:\n{selfScore.ToString("N0")}";
            SaveSystem.SaveScore(selfScore);
            return;
        }
        _bestScoreText.text = $"Best score:\n{bestScore.ToString("N0")}";
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
        _scoreInGameText.text = $"Score:\n{score.ToString("N0")}";
    }
    public void PauseGame()
    {
        GeneralGameManager.PauseGame();
    }
    public void RestartGame()
    {
        GeneralGameManager.ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitToMenu()
    {
        GeneralGameManager.ChangeScene(0);
    }
    private IEnumerator DisplayDamage()
    {
        _damageBackground.SetActive(true);

        yield return new WaitForSeconds(_damageDisplayTime);

        _damageBackground.SetActive(false);
    }
    private IEnumerator StartCountdown()
    {
        float currentTime = _countDownTime;

        while (currentTime > 0)
        {
            _counterText.text = currentTime.ToString("0");

            yield return new WaitForSeconds(1f);

            currentTime -= 1;
        }

        _counterText.text = "START!";

        yield return new WaitForSeconds(1f);

        _counterText.gameObject.SetActive(false);
        OnStartRace?.Invoke();
    }
}
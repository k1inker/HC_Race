using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public PlayerLocomotion playerLocomotion;

    private TemporaryBooster _temporaryBooster;
    private float currentTime = 0f;
    private bool isTimerStart = false;
    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPickable pickUp))
        {
            pickUp.PickUp(this);
        }
    }
    public void TakeBooster(TemporaryBooster booster)
    {
        //if player have booster and pickup another
        if (_temporaryBooster != null)
        {
            _temporaryBooster.StopAction(this);
        }

        _temporaryBooster = booster;
        _temporaryBooster.StartAction(this);

        isTimerStart = true;
        currentTime = _temporaryBooster.duration;
    }
    private void FixedUpdate()
    {
        if(!isTimerStart)
        {
            return;
        }

        currentTime -= Time.fixedDeltaTime;
        ManagerUI.Instance.SetValueBooster(currentTime);

        if(currentTime <= 0)
        {
            _temporaryBooster.StopAction(this);
            _temporaryBooster = null;
            isTimerStart = false;
        }
    }
}

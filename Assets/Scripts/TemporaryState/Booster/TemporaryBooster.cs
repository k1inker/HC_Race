using UnityEngine;

public abstract class TemporaryBooster : TemporaryState
{
    [Header("For UI Slider")]
    public string nameBooster;
    public Sprite imgSlider;

    [Header("Skins")]
    public Sprite skinPlayer;
    public Sprite skinEffect;
    private void OnEnable()
    {
        if(PlayerStats.Instance != null)
            PlayerStats.Instance.OnDeath += StopAction;
    }
    private void OnDisable()
    {
        PlayerStats.Instance.OnDeath -= StopAction;
    }
    public override void StartAction()
    {
        ManagerUI.Instance.SetupBooster(this);
        PlayerSkin.Instance.SetSkin(skinPlayer);
        PlayerSkin.Instance.SetEffect(skinEffect);
    }
    public override void StopAction()
    {
        ManagerUI.Instance.DisableBooster();
        PlayerSkin.Instance.ResetEffects();
        PlayerSkin.Instance.ResetSkin();
    }
    public override void UpdateAction(ref float time)
    {
        time -= Time.fixedDeltaTime;
        ManagerUI.Instance.SetBooster(time);
    }
}

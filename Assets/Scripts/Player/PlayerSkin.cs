using UnityEngine;

public class PlayerSkin : Singelton<PlayerSkin>
{
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private SpriteRenderer _renderEffect;

    private Sprite defaultSprite;
    private void Start()
    {
        defaultSprite = _render.sprite;
    }
    public void SetSkin(Sprite newSkin)
    {
        _render.sprite = newSkin;
    }
    public void SetEffect(Sprite effect)
    {
        _renderEffect.sprite = effect;
    }
    public void ResetSkin()
    {
        _render.sprite = defaultSprite;
    }
    public void ResetEffects()
    {
        _renderEffect.sprite = null;
    }
}

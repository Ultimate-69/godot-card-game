using Godot;
using System;

public partial class Card : Control
{

    [Export]
    public CardResource cardResource;

    [Export]
    public TextureRect image;
    [Export]
    public Label name;
    [Export]
    public Label cost;
    [Export]
    public Label power;
    [Export]
    public Button cardButton;

    bool isActive;
    Tween tween;
    public override void _Ready()
    {
        base._Ready();
        if (cardResource == null) return;
        name.Text = cardResource.cardName;
        cost.Text = cardResource.cardCost.ToString();
        power.Text = cardResource.cardPower.ToString();
        image.Texture = cardResource.cardImage;

        cardButton.Pressed += () => OnPressed();
        cardButton.GrabFocus();
    }

    void OnPressed()
    {
        CardEffects.ChangeSelectedCard(this);
    }

    public void Select()
    {
        isActive = true;
        tween = GetTree().CreateTween();
        tween.TweenProperty(this, "scale", new Vector2(1.1f, 1.1f), 0.1f);
    }

    public void DeSelect()
    {
        isActive = false;
        tween = GetTree().CreateTween();
        tween.TweenProperty(this, "scale", new Vector2(1.0f, 1.0f), 0.1f);
    }

    public void OnReveal()
    {
        CardEffects.OnReveal(cardResource);
    }

    public void OnGoing()
    {
        CardEffects.OnGoing(cardResource);
    }

    public void OnTurnEnd()
    {
        CardEffects.OnTurnEnd(cardResource);
    }

    public void OnTurnStart()
    {
        CardEffects.OnTurnStart(cardResource);
    }

    public void OnDiscard()
    {
        CardEffects.OnDiscard(cardResource);
    }

    public void OnDestroy()
    {
        CardEffects.OnDestroy(cardResource);
    }

    public void OnMove()
    {
        CardEffects.OnMove(cardResource);
    }

    public void OnGameStart()
    {
        CardEffects.OnGameStart(cardResource);
    }

    public void OnGameEnd()
    {
        CardEffects.OnGameEnd(cardResource);
    }

}

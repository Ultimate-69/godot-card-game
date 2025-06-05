using Godot;
using System;

public partial class Card : Control
{

    public CardEffects.Locations location = CardEffects.Locations.None;

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

        cardButton.MouseEntered += () => Select();
        cardButton.MouseExited += () => DeSelect(true);
    }

    void OnPressed()
    {
        if (CardEffects.selectedCard == this)
        {
            CardEffects.ChangeSelectedCard(null);
            return;
        }
        CardEffects.ChangeSelectedCard(this);
    }

    public void Select()
    {
        isActive = true;
        tween = GetTree().CreateTween();
        tween.TweenProperty(this, "scale", new Vector2(1.1f, 1.1f), 0.1f);
    }

    public void DeSelect(bool hover = false)
    {
        if (hover && CardEffects.selectedCard == this) return;
        isActive = false;
        tween = GetTree().CreateTween();
        tween.TweenProperty(this, "scale", new Vector2(1.0f, 1.0f), 0.1f);
    }

    public void OnReveal()
    {
        CardEffects.OnReveal(this);
    }

    public void OnGoing()
    {
        CardEffects.OnGoing(this);
    }

    public void OnTurnEnd()
    {
        CardEffects.OnTurnEnd(this);
    }

    public void OnTurnStart()
    {
        CardEffects.OnTurnStart(this);
    }

    public void OnDiscard()
    {
        CardEffects.OnDiscard(this);
    }

    public void OnDestroy()
    {
        CardEffects.OnDestroy(this);
    }

    public void OnMove()
    {
        CardEffects.OnMove(this);
    }

    public void OnGameStart()
    {
        CardEffects.OnGameStart(this);
    }

    public void OnGameEnd()
    {
        CardEffects.OnGameEnd(this);
    }

}

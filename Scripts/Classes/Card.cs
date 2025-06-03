using Godot;
using System;

public partial class Card : Control
{

    [Export] public CardResource cardResource;


    [Export] public TextureRect image;
    [Export] public Label name;
    [Export] public Label cost;
    [Export] public Label power;
    public override void _Ready()
    {
        base._Ready();
        if (cardResource == null) return;
        name.Text = cardResource.cardName;
        cost.Text = cardResource.cardCost.ToString();
        power.Text = cardResource.cardPower.ToString();
        image.Texture = cardResource.cardImage;
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

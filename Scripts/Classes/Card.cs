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

    }

    public void OnGoing()
    {

    }

    public void OnTurnEnd()
    {

    }

    public void OnDiscard()
    {

    }

    public void OnDestroy()
    {

    }

    public void OnMove()
    {

    }

    public void OnGameStart()
    {

    }

    public void OnGameEnd()
    {

    }

}

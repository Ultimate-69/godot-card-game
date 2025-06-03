using Godot;
using System;

public partial class Card : Control
{
    [Export] public string cardName;
    [Export] public int cardCost;
    [Export] public int cardPower;
    [Export] public Texture2D cardImage;

    [Export] public TextureRect image;
    [Export] public Label name;
    [Export] public Label cost;
    [Export] public Label power;
    public override void _Ready()
    {
        base._Ready();
        name.Text = cardName;
        cost.Text = cardCost.ToString();
        power.Text = cardPower.ToString();
        image.Texture = cardImage;
    }

    public virtual void OnReveal()
    {

    }

    public virtual void OnGoing()
    {

    }

    public virtual void OnTurnEnd()
    {

    }

    public virtual void OnDiscard()
    {

    }

    public virtual void OnDestroy()
    {

    }

    public virtual void OnMove()
    {

    }

    public virtual void OnGameStart()
    {

    }

    public virtual void OnGameEnd()
    {

    }

}

using Godot;
using System;

public partial class CardResource : Resource
{
    public enum CardType
    {
        OnReveal = 0,
        OnGoing = 1,
        Other = 2
    }

    [Export]
    public string cardName;
    [Export(PropertyHint.MultilineText)]
    public string cardText;
    [Export]
    public CardType cardType;
    [Export]
    public int cardCost;
    [Export]
    public int cardPower;
    [Export]
    public Texture2D cardImage;
}

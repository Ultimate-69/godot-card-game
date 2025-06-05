using Godot;
using System;

public partial class Location : Control
{

    enum CardLocations
    {
        Top = 0,
        Bottom = 1,
    }

    [Export]
    public LocationResource locationResource;

    [Export]
    public TextureRect image;
    [Export]
    public Label name;
    [Export]
    public Label effect;
    [Export]
    public Label powerTop;
    [Export]
    public Label powerBottom;
    [Export]
    public Button locationButton;
    [Export]
    public GridContainer topGrid;
    [Export]
    public GridContainer bottomGrid;

    Card[] cardsTop = new Card[4];
    Card[] cardsBottom = new Card[4];

    Tween tween;

    public override void _Ready()
    {
        base._Ready();
        locationButton.Pressed += () =>
        {
            if (CardEffects.selectedCard == null || CardEffects.selectedCard is not Card) return;
            if (AllocateCardToLocation(CardLocations.Bottom))
            {
                CardEffects.selectedCard.cardButton.QueueFree();
                CardEffects.selectedCard.Reparent(bottomGrid);
                CardEffects.ChangeSelectedCard(null);
                CalculatePower();
            }
        };
    }

    // The bool manages if it allocates to the top array or bottom array.
    // If it returns true, success. Otherwise, fail.
    private bool AllocateCardToLocation(CardLocations location)
    {
        if (location == CardLocations.Top)
        {
            for (int i = 0; i < cardsTop.Length; i++)
            {
                if (cardsTop[i] == null)
                {
                    cardsTop[i] = CardEffects.selectedCard;
                    return true;
                }
            }
        }
        else if (location == CardLocations.Bottom)
        {
            for (int i = 0; i < cardsBottom.Length; i++)
            {
                if (cardsBottom[i] == null)
                {
                    cardsBottom[i] = CardEffects.selectedCard;
                    return true;
                }
            }
        }
        return false;
    }

    public void CalculatePower()
    {
        foreach (Card card in cardsTop)
        {
            if (card == null) continue;
            powerTop.Text = (powerTop.Text.ToInt() + card.cardResource.cardPower).ToString();
        }

        foreach (Card card in cardsBottom)
        {
            if (card == null) continue;
            powerBottom.Text = (powerBottom.Text.ToInt() + card.cardResource.cardPower).ToString();
        }
    }

}

using Godot;
using System;

public partial class Location : Control
{
    [Export]
    public CardEffects.Locations location;

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

    int topPower = 0;
    int bottomPower = 0;

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
                CardEffects.selectedCard.location = location;
                CardEffects.ChangeSelectedCard(null);
                CalculatePower();
            }
        };
    }

    // The bool manages if it allocates to the top array or bottom array.
    // If it returns true, success. Otherwise, fail.
    private bool AllocateCardToLocation(CardLocations cardLocation)
    {
        if (cardLocation == CardLocations.Top)
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
        else if (cardLocation == CardLocations.Bottom)
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
        topPower = 0;
        bottomPower = 0;

        foreach (Card card in cardsTop)
        {
            if (card == null) continue;
            topPower += card.cardResource.cardPower;
        }

        foreach (Card card in cardsBottom)
        {
            if (card == null) continue;
            bottomPower += card.cardResource.cardPower;
        }
        powerTop.Text = topPower.ToString();
        powerBottom.Text = bottomPower.ToString();
    }

}

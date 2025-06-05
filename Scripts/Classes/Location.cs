using Godot;
using System;

public partial class Location : Control
{
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
            if (AllocateCardToLocation(false))
            {
                GD.Print("Remember to implement card removal from the arrays.");
                powerBottom.Text = (powerBottom.Text.ToInt() + CardEffects.selectedCard.cardResource.cardPower).ToString();
                CardEffects.selectedCard.cardButton.QueueFree();
                CardEffects.selectedCard.Reparent(bottomGrid);
                CardEffects.ChangeSelectedCard(null);
            }
        };
    }

    // The bool manages if it allocates to the top array or bottom array.
    // If it returns true, success. Otherwise, fail.
    private bool AllocateCardToLocation(bool top)
    {
        if (top)
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
        else
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

}

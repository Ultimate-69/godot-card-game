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

    Card[] cardsTop = new Card[4];
    Card[] cardsBottom = new Card[4];

    public override void _Ready()
    {
        base._Ready();
        locationButton.Pressed += () =>
        {
            powerBottom.Text = (powerBottom.Text.ToInt() + CardEffects.selectedCard.cardResource.cardPower).ToString();
            CardEffects.selectedCard.cardButton.Disabled = true;
            CardEffects.ChangeSelectedCard(null);
        };
    }

}

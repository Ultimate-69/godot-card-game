using Godot;
using System;
using System.Linq;

public partial class CardEffects : Node
{
    public enum Locations
    {
        None = 0,
        Left = 1,
        Middle = 2,
        Right = 3
    }

    public static Location[] locations;
    public static Card selectedCard;

    public override void _Ready()
    {
        base._Ready();
        Node game = GetParent().GetChildren()[1];
        locations =  game.GetChildren().OfType<Location>().ToArray();
    }

    public static void ChangeSelectedCard(Card card)
    {
        if (selectedCard != null)
        {
            selectedCard.DeSelect();
        }

        if (card != null)
        {
            selectedCard = card;
            selectedCard.Select();
        }
        else
        {
            selectedCard = null;
        }
    }

    public static void OnReveal(Card card)
    {
        if (card.cardResource.cardName == "Omni-Man")
        {
            foreach (Location location in locations)
            {
                GridContainer[] grids = location.GetChildren().OfType<GridContainer>().ToArray();
                foreach (GridContainer grid in grids)
                {
                    foreach (Card enumeratedCard in grid.GetChildren().OfType<Card>().ToArray())
                    {
                        if (enumeratedCard.cardResource.cardCost == 2)
                        {
                            enumeratedCard.OnDestroy();
                        }
                    }
                }
            }
        }
    }

    public static void OnGoing(Card card)
    {

    }

    public static void OnTurnEnd(Card card)
    {

    }

    public static void OnTurnStart(Card card)
    {

    }

    public static void OnDiscard(Card card)
    {

    }

    public static void OnDestroy(Card card)
    {
        if (card.cardResource.cardName == "Invincible")
        {
            return;
        }
        else
        {
            card.QueueFree();
            GD.Print("Now implement removing from location and stuff.");
        }
    }

    public static void OnMove(Card card)
    {

    }

    public static void OnGameStart(Card card)
    {

    }

    public static void OnGameEnd(Card card)
    {

    }
}

using Godot;
using System;

public partial class CardEffects : Node
{
    public static Card selectedCard;

    public static void ChangeSelectedCard(Card card)
    {
        GD.Print(5);
        if (selectedCard  != null)
        {
            selectedCard.DeSelect();
        }
        selectedCard = card;
        selectedCard.Select();
    }

    public static void OnReveal(CardResource card)
    {

    }

    public static void OnGoing(CardResource card)
    {

    }

    public static void OnTurnEnd(CardResource card)
    {

    }

    public static void OnTurnStart(CardResource card)
    {

    }

    public static void OnDiscard(CardResource card)
    {

    }

    public static void OnDestroy(CardResource card)
    {

    }

    public static void OnMove(CardResource card)
    {

    }

    public static void OnGameStart(CardResource card)
    {

    }

    public static void OnGameEnd(CardResource card)
    {

    }
}

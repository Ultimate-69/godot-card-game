using Godot;
using System;

public partial class CardEffects : Node
{
    public static Card selectedCard;

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

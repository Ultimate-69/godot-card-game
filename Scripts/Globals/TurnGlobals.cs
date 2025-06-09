using Godot;
using System;
using System.Collections.Generic;

public partial class TurnGlobals : Node
{
    public static List<Card> gameCards = new List<Card>();
    public static List<Location> gameLocations = new List<Location>();
    public static void AdvanceTurn()
    {
        foreach (Card card in gameCards)
        {
            card.OnTurnStart();
            // do something abt on turn end
        }

        foreach (Location location in gameLocations)
        {
            location.OnTurnStart();
        }
    }
}

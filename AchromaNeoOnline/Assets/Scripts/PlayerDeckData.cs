using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckData
{
    public string playerName;
    public int rank;
    public int points;

    public int wins;
    public int matches;

    public string[] deckCards;

    public PlayerDeckData(PlayerInfo playerInfo)
    {
        playerName = playerInfo.playerName;
        rank = playerInfo.rank;
        points = playerInfo.points;
        wins = playerInfo.wins;
        matches = playerInfo.matches;

        List<DeckInfo> deckInfo = playerInfo.decks;
        int totalSize = 0;

        foreach (DeckInfo deck in deckInfo) {
            // First one is name
            // Second one is character
            // Every odds is action card name
            // Every evens is action card amount
            totalSize += deck.actionCards.Count * 2 + 2;
        }

        deckCards = new string[totalSize];

        int counter = 0;
        foreach (DeckInfo deck in deckInfo)
        {
            deckCards[counter] = deck.deckName;
            counter++;
            deckCards[counter] = deck.character;
            counter++;

            foreach(string cardname in deck.actionCards.Keys)
            {
                deckCards[counter] = cardname;
                counter++;
                deckCards[counter] = deck.actionCards[cardname].ToString();
                counter++;
            }
        }
    }
}

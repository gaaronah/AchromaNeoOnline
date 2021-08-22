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

    public int gold;
    public int essence;

    public string[] deckCards;
    public string[] ownedActions;
    public string[] ownedCharacters;

    public PlayerDeckData(PlayerInfo playerInfo)
    {
        playerName = playerInfo.playerName;
        rank = playerInfo.rank;
        points = playerInfo.points;
        wins = playerInfo.wins;
        matches = playerInfo.matches;
        gold = playerInfo.gold;
        essence = playerInfo.essence;

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

        ownedActions = new string[playerInfo.collection.ownedActions.Count];
        for (int i = 0; i < ownedActions.Length; i++)
        {
            ownedActions[i] = playerInfo.collection.ownedActions[i];
        }

        ownedCharacters = new string[playerInfo.collection.ownedCharacters.Count];
        for (int i = 0; i < ownedCharacters.Length; i++)
        {
            ownedCharacters[i] = playerInfo.collection.ownedCharacters[i];
        }
    }
}

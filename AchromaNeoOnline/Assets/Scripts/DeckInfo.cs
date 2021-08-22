using System.Collections.Generic;

public class DeckInfo
{
    public string deckName;
    public string character;
    public Dictionary<string, int> actionCards = new Dictionary<string, int>();

    public void AddCard(string cardName, int cardAmount)
    {
        if (!actionCards.ContainsKey(cardName) || 
            actionCards[cardName] + cardAmount <= Constants.CARD_LIMIT)
        {
            actionCards.Add(cardName, cardAmount);
        }
    }
}

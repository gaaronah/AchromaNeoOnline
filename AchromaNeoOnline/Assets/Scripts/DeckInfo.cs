using System.Collections.Generic;

public class DeckInfo
{
    public string deckName;
    public string character;
    public Dictionary<string, int> actionCards = new Dictionary<string, int>();

    public void AddCard(string cardName, int cardAmount)
    {
        if(cardName.Equals("Attack"))
        {
            if (!actionCards.ContainsKey(cardName))
            {
                actionCards.Add(cardName, 10);
            }
        }
        else if (cardName.Equals("Chroma Attack"))
        {
            if (!actionCards.ContainsKey(cardName))
            {
                actionCards.Add(cardName, 4);
            }
        }
        else if (!actionCards.ContainsKey(cardName))
        {
            actionCards.Add(cardName, cardAmount);
        }
        else if (actionCards[cardName] + cardAmount <= Constants.CARD_LIMIT)
        {
            actionCards[cardName] += cardAmount;
        }
    }
}

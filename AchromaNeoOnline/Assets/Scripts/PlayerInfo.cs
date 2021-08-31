using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo playerInfo { get; private set; }

    public string playerName;
    public int rank;
    public int points;

    public int wins;
    public int matches;

    public int gold;
    public int essence;

    public List<DeckInfo> decks;
    public CollectionInfo collection;


    public List<CharacterCard> characterCardList;
    public List<ActionCard> actionCardList;

    void Awake()
    {
        if (playerInfo == null)
        {
            Debug.Log("First player info.");
            playerInfo = this;
            DontDestroyOnLoad(gameObject);

            decks = new List<DeckInfo>();
            collection = new CollectionInfo();
            LoadCardLists();
            LoadInfo();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadInfo()
    {
        PlayerDeckData data = SaveSystem.LoadPlayerDeckInfo();

        if (data != null)
        {
            playerName = data.playerName;
            rank = data.rank;
            points = data.points;
            wins = data.wins;
            matches = data.matches;
            gold = data.gold;
            essence = data.essence;

            int deckSize = 0;
            int deckCount = 0;
            for (int i = 0; i < data.deckCards.Length; i++)
            {
                if (deckSize == 0)
                {
                    decks.Add(new DeckInfo());
                    deckCount++;
                    decks[deckCount - 1].deckName = data.deckCards[i];
                    decks[deckCount - 1].character = data.deckCards[i + 1];
                    i += 2;
                }
                decks[deckCount - 1].AddCard(data.deckCards[i], int.Parse(data.deckCards[i + 1]));
                deckSize += int.Parse(data.deckCards[i + 1]);
                i++;
                if (deckSize >= Constants.DECK_SIZE)
                {
                    deckSize = 0;
                }
            }

            for (int i = 0; i < data.ownedActions.Length; i++)
            {
                collection.ownedActions.Add(data.ownedActions[i]);
            }

            for (int i = 0; i < data.ownedCharacters.Length; i++)
            {
                collection.ownedCharacters.Add(data.ownedCharacters[i]);
            }
        }
        else
        {
            Debug.Log("No save data found, initializing data");
            ResetData();
        }

        ListDecks();
    }

    public void SaveInfo()
    {
        Debug.Log("Saving player info");
        SaveSystem.SavePlayerDeckInfo(this);
    }

    public void IncreasePoints(int i)
    {
        points += i;
        if (points >= Constants.POINTS_LIMIT)
        {
            points -= Constants.POINTS_LIMIT;
            IncreaseRank();
        }
        else
        {
            SaveInfo();
        }
    }

    public void IncreaseRank()
    {
        rank++;
        SaveInfo();
    }

    public void UpdateName(string s)
    {
        if (playerName != s)
        {
            playerName = s;
            SaveInfo();
        }
    }

    public void IncreaseMatches()
    {
        matches++;
        SaveInfo();
    }

    public void IncreaseWins()
    {
        wins++;
        SaveInfo();
    }

    public void ResetData()
    {
        decks = new List<DeckInfo>();
        collection = new CollectionInfo();

        playerName = "New Name";
        rank = 0;
        points = 0;
        wins = 0;
        matches = 0;
        gold = 500;
        essence = 0;

        // When no data is found, initiallizes 4 decks for player to use
        // Starter red deck -> Ares
        DeckInfo aresDeck = new DeckInfo();
        aresDeck.deckName = "Red: Ares";
        aresDeck.character = "Ares";
        // 1 Cost Actions
        aresDeck.AddCard("Attack", Constants.ATTACK_AMT); // 10
        aresDeck.AddCard("Chroma Attack", Constants.CHROMA_AMT); // 14
        aresDeck.AddCard("Smite", 4); // 18
        aresDeck.AddCard("Extra Life", 4); // 22
                                           // 2 Cost Actions
        aresDeck.AddCard("Critical Attack", 4); // 26
        aresDeck.AddCard("Quick Attack", 4); // 30
        aresDeck.AddCard("Smite Attack", 4); // 34
        aresDeck.AddCard("Shield Attack", 3); // 37
                                              // 4 Cost Actions
        aresDeck.AddCard("Battlecry", 3); // 40

        decks.Add(aresDeck);

        // Starter green deck -> Demeter
        DeckInfo demeterDeck = new DeckInfo();
        demeterDeck.deckName = "Green: Demeter";
        demeterDeck.character = "Demeter";
        // 1 Cost Actions
        demeterDeck.AddCard("Attack", Constants.ATTACK_AMT); // 10
        demeterDeck.AddCard("Chroma Attack", Constants.CHROMA_AMT); // 14
        demeterDeck.AddCard("Ramp", 4); // 18
        demeterDeck.AddCard("Extra Life", 4); // 22
                                              // 2 Cost Actions
        demeterDeck.AddCard("Critical Attack", 4); // 26
        demeterDeck.AddCard("Shield Attack", 4); // 30
        demeterDeck.AddCard("Beast", 4); // 34
                                         // 4 Cost Actions
        demeterDeck.AddCard("Great Beast", 4); // 38
        demeterDeck.AddCard("Harvest", 2); // 40

        decks.Add(demeterDeck);

        // Starter blue deck -> Dionysus
        DeckInfo dionysusDeck = new DeckInfo();
        dionysusDeck.deckName = "Blue: Dionysus";
        dionysusDeck.character = "Dionysus";
        // 1 Cost Actions
        dionysusDeck.AddCard("Attack", Constants.ATTACK_AMT); // 10
        dionysusDeck.AddCard("Chroma Attack", Constants.CHROMA_AMT); // 14
        dionysusDeck.AddCard("Peek", 4); // 18
        dionysusDeck.AddCard("Extra Life", 4); // 22
        dionysusDeck.AddCard("Bless", 4); // 26
                                          // 2 Cost Actions
        dionysusDeck.AddCard("Critical Attack", 4); // 30
        dionysusDeck.AddCard("Steal Attack", 4); // 34
        dionysusDeck.AddCard("Shield Attack", 3); // 37
                                                  // 4 Cost Actions
        dionysusDeck.AddCard("Insanity", 3); // 40

        decks.Add(dionysusDeck);

        // Starter yellow deck -> Athena
        DeckInfo athenaDeck = new DeckInfo();
        athenaDeck.deckName = "Yellow: Athena";
        athenaDeck.character = "Athena";
        // 1 Cost Actions
        athenaDeck.AddCard("Attack", Constants.ATTACK_AMT); // 10
        athenaDeck.AddCard("Chroma Attack", Constants.CHROMA_AMT); // 14
        athenaDeck.AddCard("Craft", 4); // 18
        athenaDeck.AddCard("Extra Life", 4); // 22
                                             // 2 Cost Actions
        athenaDeck.AddCard("Critical Attack", 4); // 26
        athenaDeck.AddCard("Shield Attack", 4); // 30
        athenaDeck.AddCard("Quick Attack", 4); // 34
        athenaDeck.AddCard("Craft Attack", 4); // 38
                                               // 4 Cost Actions
        athenaDeck.AddCard("Agility", 2); // 40

        decks.Add(athenaDeck);

        // Starting collection of characters
        collection.ownedCharacters.Add("Ares");
        collection.ownedCharacters.Add("Demeter");
        collection.ownedCharacters.Add("Dionysus");
        collection.ownedCharacters.Add("Athena");

        // Starting collection of action cards
        collection.ownedActions.Add("Attack");
        collection.ownedActions.Add("Chroma Attack");
        collection.ownedActions.Add("Smite");
        collection.ownedActions.Add("Extra Life");
        collection.ownedActions.Add("Critical Attack");
        collection.ownedActions.Add("Smite Attack");
        collection.ownedActions.Add("Quick Attack");
        collection.ownedActions.Add("Shield Attack");
        collection.ownedActions.Add("Battlecry");
        collection.ownedActions.Add("Ramp");
        collection.ownedActions.Add("Beast");
        collection.ownedActions.Add("Great Beast");
        collection.ownedActions.Add("Harvest");
        collection.ownedActions.Add("Peek");
        collection.ownedActions.Add("Bless");
        collection.ownedActions.Add("Steal Attack");
        collection.ownedActions.Add("Insanity");
        collection.ownedActions.Add("Craft Attack");
        collection.ownedActions.Add("Quick Draw");
        collection.ownedActions.Add("Agility");

        SaveInfo();

        ListDecks();
    }

    public void ListDecks()
    {
        Debug.Log("List Decks:");
        foreach (DeckInfo deck in decks)
        {
            Debug.Log(deck.deckName);
        }
    }

    public void AddCharacter(CharacterCard card)
    {
        collection.ownedCharacters.Add(card.characterName);
        SaveInfo();
    }

    public void RemoveCharacter(CharacterCard card)
    {
        if (collection.ownedCharacters.Contains(card.characterName))
        {
            collection.ownedCharacters.Remove(card.characterName);
            SaveInfo();
        }
    }

    public void AddAction(ActionCard card)
    {
        collection.ownedCharacters.Add(card.cardName);
        SaveInfo();
    }

    public void LoadCardLists()
    {
        characterCardList = new List<CharacterCard>();
        actionCardList = new List<ActionCard>();

        // Loading all characters:
        LoadCharacterCard("Aether");
        LoadCharacterCard("Ares");
        LoadCharacterCard("Demeter");
        LoadCharacterCard("Dionysus");
        LoadCharacterCard("Athena");
        LoadCharacterCard("Hades");
        LoadCharacterCard("Artemis");
        LoadCharacterCard("Poseidon");
        LoadCharacterCard("Zeus");
        LoadCharacterCard("Thanatos");

        // Loading all actions:
        LoadActionCardBase("Attack"); // 1
        LoadActionCardBase("Chroma Attack"); // 2
        LoadActionCardBase("Extra Life"); // 3
        LoadActionCardBase("Smite"); // 4
        LoadActionCardBase("Ramp"); // 5
        LoadActionCardBase("Peek"); // 6
        LoadActionCardBase("Bless"); // 7
        LoadActionCardBase("Quick Draw"); // 8
        LoadActionCardBase("Critical Attack"); // 9
        LoadActionCardBase("Shield Attack"); // 10
        LoadActionCardBase("Smite Attack"); // 11
        LoadActionCardBase("Quick Attack"); // 12
        LoadActionCardBase("Beast"); // 13
        LoadActionCardBase("Steal Attack"); // 14
        LoadActionCardBase("Craft Attack"); // 15 
        LoadActionCardBase("Battlecry"); // 16
        LoadActionCardBase("Great Beast"); // 17
        LoadActionCardBase("Harvest"); // 18
        LoadActionCardBase("Insanity"); // 19 
        LoadActionCardBase("Agility"); // 20

        LoadActionCardSet1("Drag Down"); // 21 
        LoadActionCardSet1("Attack Order"); // 22 
        LoadActionCardSet1("Storm"); // 23
        LoadActionCardSet1("Trading Smite"); // 24
        LoadActionCardSet1("Trade Attack"); // 25
        LoadActionCardSet1("Preparation"); // 26
        LoadActionCardSet1("Greater Extra Life"); // 27
        LoadActionCardSet1("Destroy"); // 28
        LoadActionCardSet1("Ramp Attack"); // 29
        LoadActionCardSet1("Burst Attack"); // 30
        LoadActionCardSet1("Chaos Attack"); // 31 
        LoadActionCardSet1("Multi Shield"); // 32
        LoadActionCardSet1("Craft"); // 33
        LoadActionCardSet1("Chain Attack"); // 34
        LoadActionCardSet1("Delayed Attack"); // 35
        LoadActionCardSet1("Torture"); // 36
        LoadActionCardSet1("Ascend Beasts"); // 37
        LoadActionCardSet1("Heavy Storm"); // 38
        LoadActionCardSet1("Almighty Smite"); // 39
        LoadActionCardSet1("Heavenly Image"); // 40 

        LoadActionCardSpecialSet1("Death's Hand"); // 41
        LoadActionCardSpecialSet1("Healing Ritual"); // 42
        LoadActionCardSpecialSet1("Destruction Ritual"); // 43
        LoadActionCardSpecialSet1("Chaos Destroy"); // 44
        LoadActionCardSpecialSet1("Final Wrath"); // 45
    }

    public void LoadActionCardBase(string s)
    {
        GameObject e = Resources.Load("Prefabs/ActionPrefabs/BaseSet/" + s) as GameObject;
        actionCardList.Add(e.GetComponent<ActionCard>());
    }

    public void LoadActionCardSet1(string s)
    {
        GameObject e = Resources.Load("Prefabs/ActionPrefabs/FirstContactWithLegends/" + s) as GameObject;
        actionCardList.Add(e.GetComponent<ActionCard>());
    }

    public void LoadActionCardSpecialSet1(string s)
    {
        GameObject e = Resources.Load("Prefabs/ActionPrefabs/SpecialSetThanatos/" + s) as GameObject;
        actionCardList.Add(e.GetComponent<ActionCard>());
    }

    public void LoadCharacterCard(string s)
    {
        GameObject e = Resources.Load("Prefabs/CharacterPrefabs/" + s) as GameObject;
        characterCardList.Add(e.GetComponent<CharacterCard>());
    }
}

Dealer dealer = new Dealer();
Console.WriteLine((dealer.GetCard()).GetName());
class Deck
{
    private List<Card> deck;
    public Deck()
    {
        deck = new List<Card>();
        for (int i = 1; i <= 13; i++)
        {
            deck.Add(new Card(i, "Diamonds"));
            deck.Add(new Card(i, "Clubs"));
            deck.Add(new Card(i, "Hearts"));
            deck.Add(new Card(i, "Spades"));
        }
        Console.WriteLine("A new deck has been created.\n");
    }

    public Card TopCard()
    {
        Card card = deck[0];
        deck.RemoveAt(0);
        return card;
    }
    
    public void DisplayDeck()
    {
        Console.WriteLine("Displaying deck: \n");
        foreach (Card c in deck)
        {
            Console.WriteLine(c.GetName());
        }
    }

    public void Shuffle()
    {
        Console.WriteLine("Shuffling deck: \n");
        int n = deck.Count;
        System.Random random = new System.Random();
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }
}
class Card
{
    private int numval;
    private string suit;

    public Card(int numval, string suit)
    {
        this.numval = numval;
        this.suit = suit;
    }

    public int GetValue()
    {
        return numval;
    }
    public string GetName()
    {
        string displayName = "";
        switch (numval)
        {
            case 1:
                displayName = "Ace";
                break;
            case 11:
                displayName = "Jack";
                break;
            case 12:
                displayName = "Queen";
                break;
            case 13:
                displayName = "King";
                break;
            default:
                displayName = numval.ToString();
                break;
        }

        return displayName + " of " + suit;
    }
}
class Player
{
    private string playerName;
    private List<Card> hand;

    public Player(string playerName)
    {
        this.playerName = playerName;
        
        hand = new List<Card>();
        
        Console.WriteLine("A new player, "+this.playerName+", has been instantiated with an empty hand. " + this.playerName + " needs to be able to play Blackjack, i.e. continuously get cards from the dealer until he reaches a cardvalue of 21 or goes bust, or chooses to stick if he gets close to 21 and risks going bust if he takes anymore cards.\n");
    }

    public int GetCardFromDealer(Dealer d)
    {
        Card c = d.GetCard();
        hand.Add(c);
        
        Console.WriteLine(playerName+" takes a card from the dealer and puts it in his hand. The card is: "+c.GetName()+"\n");
        return c.GetValue();
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}
class Dealer
{
    private Deck deck;
    
    public Dealer()
    {
        deck = new Deck();
        deck.Shuffle();
        deck.DisplayDeck();
    }

    public Card GetCard()
    {
        Console.WriteLine("Dealing deck: \n");
        return deck.TopCard();
    }
}

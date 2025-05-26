using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            string again = "y";
            while (again == "y")
            {
                List<int> values = new List<int>();
                List<int> index = new List<int>();
                List<string> names = new List<string>();
                int highest = 0;
                Dealer dealer = new Dealer();
                
                Console.Write("Enter the number of players: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

                // Player turns
                for (int i = 0; i < num; i++)
                {
                    int total = 0;
                    string choice = "2";
                    Console.Write("Please enter the name of the player: ");
                    string name = Console.ReadLine();
                    Console.Write("\n");   
                    names.Add(name);
                    Player player = new Player(name);
                    
                    // Initial two cards
                    total += player.GetCardFromDealer(dealer);
                    total += player.GetCardFromDealer(dealer);

                    while (choice == "2")
                    {
                        Console.WriteLine($"{name}'s total value: {total}");
                        Console.WriteLine("Do you want to stick or hit?");
                        Console.WriteLine("1: Stick");
                        Console.WriteLine("2: Hit");
                        choice = "3";
                        while (choice != "1" && choice != "2")
                        {
                            choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                values.Add(total);
                            }
                            else if (choice == "2")
                            {
                                total += player.GetCardFromDealer(dealer);
                                if (total > 21)
                                {
                                    Console.WriteLine($"{name} busts with {total}!");
                                    values.Add(total);
                                    choice = "1";
                                }
                            }
                            else
                            {
                                Console.WriteLine("That's not a valid choice. Enter again.");
                            }
                        }
                    }
                }

                // Dealer's turn
                int dealerTotal = dealer.PlayDealerHand();
                Console.WriteLine($"\nDealer's final total: {dealerTotal}");

                // Determine winners
                for (int i = 0; i < num; i++)
                {
                    if (values[i] > 21)
                    {
                        Console.WriteLine($"Player {names[i]} has lost as value of hand ({values[i]}) is greater than 21.");
                    } 
                    else if (values[i] == highest && values[i] != 0)
                    {
                        index.Add(i);
                    }
                    else if (values[i] <= 21 && values[i] > 0 && values[i] > highest)
                    {
                        index.Clear();
                        highest = values[i];
                        index.Add(i);
                    }
                }

                // Compare with dealer
                if (dealerTotal <= 21)
                {
                    if (highest <= dealerTotal)
                    {
                        Console.WriteLine($"\nDealer wins with {dealerTotal}!");
                        index.Clear();
                    }
                }

                if (index.Count == 1)
                {
                    Console.WriteLine($"\nPlayer {names[index[0]]} has won with {highest}!");
                }
                else if (index.Count > 1)
                {
                    Console.WriteLine("\nThere has been a draw.");
                    foreach (int i in index)
                    {
                        Console.WriteLine($"Player {names[i]} has achieved a value of {highest}");
                    }
                }
                else
                {
                    Console.WriteLine("\nThere are no winners.");
                }

                again = "hello";
                while (again != "y" && again != "n")
                {
                    Console.WriteLine("\nWould you like to play again? (y/n)");
                    again = Console.ReadLine().ToLower();
                } 
            }
        }
    }

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
            int n = deck.Count;
            Random random = new Random();
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

    class Dealer
    {
        private Deck deck;
        private List<Card> hand;
        
        public Dealer()
        {
            deck = new Deck();
            hand = new List<Card>();
            deck.Shuffle();
        }

        public Card GetCard()
        {
            return deck.TopCard();
        }

        public int PlayDealerHand()
        {
            int total = 0;
            // Dealer must hit on 16 and below, stand on 17 and above
            while (total < 17)
            {
                Card card = GetCard();
                hand.Add(card);
                total += card.GetValue();
                Console.WriteLine($"Dealer draws: {card.GetName()}");
            }
            return total;
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
            if (numval > 10)
                return 10;
            return numval;
        }

        public string GetName()
        {
            string displayName = numval switch
            {
                1 => "Ace",
                11 => "Jack",
                12 => "Queen",
                13 => "King",
                _ => numval.ToString()
            };

            return $"{displayName} of {suit}";
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
        }

        public int GetCardFromDealer(Dealer d)
        {
            Card c = d.GetCard();
            hand.Add(c);
            Console.WriteLine($"{playerName} draws: {c.GetName()}");
            return c.GetValue();
        }

        public string GetPlayerName()
        {
            return playerName;
        }
    }
}
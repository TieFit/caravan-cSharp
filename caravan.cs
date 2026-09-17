using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		Player player = new Player();
		Computer computer = new Computer();
		
		CreatePlayerDeck(player);
		player.CaravanDeck.Sort((a, b) => a.Value.CompareTo(b.Value));
		
		CreateComputerDeck(computer);
		computer.CaravanDeck.Sort((a, b) => a.Value.CompareTo(b.Value));
		
		CreatePlayerHand(player);
		player.Hand.Sort((a, b) => a.Value.CompareTo(b.Value));
		
		CreateComputerHand(computer);
		computer.Hand.Sort((a, b) => a.Value.CompareTo(b.Value));

		player.Name = "Pwayer";
		computer.Name = "Bee-Boop";
	
		Console.WriteLine(player);
		Console.WriteLine(computer);
	}
	
	public static void CreatePlayerDeck(Player player) 
	{
		Deck deck = new Deck();
		while (player.CaravanDeck.Count < 5)
		{
			Console.WriteLine($"\nChoose card {player.CaravanDeck.Count + 0}/5");
			Card card = deck.PlayerDrawCard();
			if (card != null)
			{
				player.CaravanDeck.Add(card);
			}
		}		
	}
	
	
	public static void CreateComputerDeck(Computer computer)
	{
		Deck deck = new Deck();
		while (computer.CaravanDeck.Count < 5)
		{
			Card card = deck.ComputerDrawCard();
			if (card != null) 
			{
				computer.CaravanDeck.Add(card);	
			}
		}
	}
	
	public static void CreatePlayerHand(Player player) 
	{
		while (player.Hand.Count < 3)
		{
			int randomIndex = Random.Shared.Next(player.CaravanDeck.Count);
			Card card = player.CaravanDeck[randomIndex];
			
			player.Hand.Add(card);	
			player.CaravanDeck.RemoveAt(randomIndex);
		}	
	}
	
	public static void CreateComputerHand(Computer computer)
	{
		while (computer.Hand.Count < 3)
		{
			int randomIndex = Random.Shared.Next(computer.CaravanDeck.Count);
			Card card = computer.CaravanDeck[randomIndex];
			
			computer.Hand.Add(card);
			computer.CaravanDeck.RemoveAt(randomIndex);
		}
	}
}

public class Card
{
	public string Suit { get; set; }
	public string Rank { get; set; }

	public Card(string suit, string rank)
	{
		Suit = suit;
		Rank = rank;
	}
	
	// this value is mainly for sorting CaravanDeck and Hands in order right now
	public int Value
	{
    	get
    	{
        	return Rank switch
        	{
				"Ace" => 1,
				"2" => 2,
				"3" => 3,
				"4" => 4,
				"5" => 5,
				"6" => 6,
				"7" => 7,
				"8" => 8,
				"9" => 9,
				"10" => 10,
				"Jack" => 11,
				"Queen" => 12,
				"King" => 13,
				"Joker" => 14,
				_ => 0
        	};
    	}
	}


	public override string ToString()
	{
		return $"{Rank} of {Suit}";
	}
}

public class Deck
{
	public List<Card> Cards { get; set; } = new();

	public Deck()
	{
		string[] suits =
		{
			"Hearts",
			"Diamonds",
			"Spades",
			"Clubs"
		};
		string[] ranks =
		{
			"Ace",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"10",
			"Jack",
			"Queen",
			"King",
			"Joker"
		};
		foreach (string suit in suits)
		{
			foreach (string rank in ranks)
			{
				Cards.Add(new Card(suit, rank));
			}
		}
	}

	// computer randomly draws cards to form their deck
	public Card ComputerDrawCard()
	{
		int randomIndex = Random.Shared.Next(Cards.Count);
		Card card = Cards[randomIndex];
		Cards.RemoveAt(randomIndex);
		return card;
	}

	// draw player cards and ensure no duplicates can be drawn
	public Card PlayerDrawCard()
	{
		Console.Write("Rank: ");
		string rank = Console.ReadLine();
		
		Console.Write("Suit: ");
		string suit = Console.ReadLine();
		
		Card selectedCard = Cards.Find(card => card.Rank.Equals(rank, StringComparison.OrdinalIgnoreCase) && card.Suit.Equals(suit, StringComparison.OrdinalIgnoreCase));
		if (selectedCard == null)
		{
			Console.WriteLine("That card doesn't exist.");
			return null;
		}

		Cards.Remove(selectedCard);
		return selectedCard;
	}

	public override string ToString()
	{
		return $"Cards: {Cards}";
	}
}

public class Player
{
	public string Name { get; set; }
	public List<Card> CaravanDeck { get; set; } = new();
	public List<Card> Hand { get; set; } = new();

	public void AddToCaravanDeck(Card card)
	{
		CaravanDeck.Add(card);
	}
	
	public void PlayerDrawHand(Card card) 
	{
		Hand.Add(card);
	}

	public override string ToString()
	{
		return $"\nName: {Name}\nDeck:\n	{string.Join("\n	", CaravanDeck)}\nHand:\n	{string.Join("\n	", Hand)}";
	}
}

public class Computer 
{
	public string Name { get; set; }
	public List<Card> CaravanDeck { get; set; } = new();
	public List<Card> Hand { get; set; } = new();
	
	public void AddToCaravanDeck(Card card)
	{
		CaravanDeck.Add(card);
	}
	
	public void ComputerDrawHand(Card card) 
	{
		Hand.Add(card);	
	}
	
	public override string ToString() 
	{
		return $"\nName: {Name}\nDeck:\n	{string.Join("\n	", CaravanDeck)}\nHand:\n	{string.Join("\n	", Hand)}";
	}
}
using System;
using System.Collections.Generic;

public class Program {
   	public static void Main() {
		Deck deck = new Deck();
		Player player = new Player();
		
		while (player.CaravanDeck.Count < 30)
		{
			Console.WriteLine(
				$"Choose card {player.CaravanDeck.Count + 1}/30"
			);

			Card card = deck.PlayerDrawCard();

			if (card != null)
			{
				player.CaravanDeck.Add(card);
			}
		}
		
		Card drawnCard = deck.ComputerDrawCard();
		
		player.Name = "JJ"; 
		
		Console.WriteLine(player);
	}
}

public class Card {
	public string Suit { get; set; }
	public string Rank { get; set; }
	
	public Card(string suit, string rank) {
		Suit = suit;
		Rank = rank;
	}
	
	public override string ToString() {
		return $"{Rank} of {Suit}";	
	}
}

public class Deck {
	public List<Card> Cards { get; set; } = new();
	
	public Deck() {
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
		
		foreach (string suit in suits) {
			foreach (string rank in ranks) {
				Cards.Add(
					new Card(suit, rank)
				);
			}
		}
	}
	
	// computer randomly draws cards to form their deck
	public Card ComputerDrawCard() {
		int randomIndex = Random.Shared.Next(Cards.Count);

		Card card = Cards[randomIndex];

		Cards.RemoveAt(randomIndex);

		return card;
	}
	
	
	public Card PlayerDrawCard()
	{
		Console.Write("Rank: ");
		string rank = Console.ReadLine();

		Console.Write("Suit: ");
		string suit = Console.ReadLine();

		Card selectedCard = Cards.Find(card =>
			card.Rank.Equals(rank, StringComparison.OrdinalIgnoreCase) &&
			card.Suit.Equals(suit, StringComparison.OrdinalIgnoreCase));

		if (selectedCard == null)
		{
			Console.WriteLine("That card doesn't exist.");
			return null;
		}

		Cards.Remove(selectedCard);

		return selectedCard;
	}

	public override string ToString() {
		return $"Cards: {Cards}";	
	}
}

public class Player {
	public string Name { get; set; }
	public List<Card> CaravanDeck { get; set; } = new();
	
	public void AddToCaravanDeck(Card card) {
		CaravanDeck.Add(card);	
	}
	
	public override string ToString() {
		return $"Name: {Name}\nDeck:\n{string.Join("\n", CaravanDeck)}";
	}
}
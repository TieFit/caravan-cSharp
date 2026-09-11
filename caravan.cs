using System;
using System.Collections.Generic;

public class Program {
   	public static void Main() {
		Deck deck = new Deck();
		Player player = new Player();
		
		Card drawnCard = deck.DrawCard();
		
		player.Name = "JJ"; 
		player.Hand.Add(drawnCard);
		
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
			/* Leaving out all the face cards for now as the functionality for them in caravan is more complex than the others
			"Jack",
			"Queen",
			"King",
			"Joker" */
		};
		
		foreach (string suit in suits) {
			foreach (string rank in ranks) {
				Cards.Add(
					new Card(suit, rank)
				);
			}
		}
	}
	
	public Card DrawCard() {
	Card card = Cards[0];
	
	Cards.RemoveAt(0);
	
	return card;
	}
	
	public override string ToString() {
		return $"Cards: {Cards}";	
	}
}

public class Player {
	public string Name { get; set; }
	public List<Card> Hand { get; set; } = new();
	
	public override string ToString() {
		return $"Name: {Name}\nHand: {string.Join(", ", Hand)}";
	}
}
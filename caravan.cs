using System;
using System.Collections.Generic;

public class Program {
   	public static void Main() {
		Deck deck = new Deck();
		
		Card drawnCard = deck.DrawCard();
		
		Console.WriteLine(drawnCard);
		Console.WriteLine(deck.Cards.Count);
	}
}

// Used in deck class to build the deck of cards
public class Card {
	public string Suit { get; set; }
	public string Rank { get; set; }
	
	public Card(string suit, string rank) {
		Suit = suit;
		Rank = rank;
	}
	
	public override string ToString() {
		return $"Suit: {Suit}\nRank: {Rank}";	
	}
}

// Uses card class to build the deck of cards
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
	
    // draws a card for use in the player's hand, and removes it from their deck
	public Card DrawCard() {
	Card card = Cards[0];
	
	Cards.RemoveAt(0);
	
	return card;
	}
	
	public override string ToString() {
		return $"Cards: {Cards}";	
	}
}
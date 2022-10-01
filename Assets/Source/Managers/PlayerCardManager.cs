using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCardManager : MonoBehaviour
{
    // Constants
    private const int NUMBER_OF_CARDS = 30;
    private const int MAXIMUM_CARDS_IN_HAND = 10;

    public Stack<PlayerCard> PlayerDeck { get; private set; } = new Stack<PlayerCard>(NUMBER_OF_CARDS);
    public Stack<PlayerCard> DiscardPile { get; private set; } = new Stack<PlayerCard>();
    public PlayerHand Hand { get; private set; }

    private void Awake()
    {
        List<PlayerCard> StarterDeck = Resources.LoadAll<PlayerCard>("Cards/Player").ToList();
        Utils.Shuffle(StarterDeck);

        for (int i = 0; i < Mathf.Min(StarterDeck.Count, NUMBER_OF_CARDS); i++)
        {
            PlayerDeck.Push(StarterDeck[i]);
        }

        Hand = new PlayerHand(GameObject.Find("PlayerHand"));
    }

    public void DrawCard()
    {
        if (PlayerDeck.Count > 0)
        {
            Hand.Enqueue(PlayerDeck.Pop());

            if (Hand.Count > MAXIMUM_CARDS_IN_HAND)
            {
                DiscardPile.Push(Hand.Dequeue());
            }

            Hand.ReshuffleCards();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardManager : MonoBehaviour
{
    // Constants
    private const int NUMBER_OF_CARDS = 30;
    private const int MAXIMUM_CARDS_IN_HAND = 10;

    private Stack<PlayerCard> PlayerDeck { get; } = new Stack<PlayerCard>(NUMBER_OF_CARDS);
    private Queue<PlayerCard> Hand { get; } = new Queue<PlayerCard>();
    private Stack<PlayerCard> DiscardPile { get; } = new Stack<PlayerCard>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard()
    {
        Hand.Enqueue(PlayerDeck.Pop());

        if (Hand.Count >= MAXIMUM_CARDS_IN_HAND)
        {
            DiscardPile.Push(Hand.Dequeue());
        }
    }
}

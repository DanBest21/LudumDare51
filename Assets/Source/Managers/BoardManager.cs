using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private const int MAXIMUM_ACTIVE_CARDS = 5;
    private const float DISTANCE_BETWEEN_CARDS = 2.5f;

    private GameObject Board;

    public List<ActiveCard> ActiveCards { get; private set; } = new List<ActiveCard>(MAXIMUM_ACTIVE_CARDS);

    private void Awake()
    {
        this.Board = GameObject.Find("Board"); 
    }

    public void Update()
    {
        List<int> IndicesToRemove = new List<int>();

        for (int i = 0; i < ActiveCards.Count; i++)
        {
            ActiveCard CurrentCard = ActiveCards[i];
            PlayerCard CardInfo = CurrentCard.CardInfo;

            if (CardInfo.CardType == Card.ECardType.Instant)
            {
                foreach (CardEffect Effect in CardInfo.CardEffects)
                {
                    Effect.ApplyInstantEffect();
                }

                IndicesToRemove.Add(i);
            }
        }

        int IndicesRemoved = 0;

        foreach (int Index in IndicesToRemove)
        {
            ActiveCard CurrentCard = ActiveCards[Index - IndicesRemoved];

            if (CurrentCard.CardStatus == ActiveCard.ECardStatus.Discarded)
            {
                ActiveCards.RemoveAt(Index - IndicesRemoved);

                IndicesRemoved++;
            }
            else if (CurrentCard.CardStatus != ActiveCard.ECardStatus.Discarding)
            {
                CurrentCard.DiscardCard();
            }
        }

        if (IndicesRemoved > 0)
        {
            ReshuffleBoard();
        }
    }

    public void PlayCard(ActiveCard NewCard)
    {
        NewCard.Position = ActiveCards.Count;
        NewCard.CardStatus = ActiveCard.ECardStatus.OnBoard;

        ActiveCards.Add(NewCard);

        NewCard.transform.SetParent(Board.transform);

        ReshuffleBoard();
    }

    public void ReshuffleBoard()
    {
        Vector2 CentralPosition = Board.transform.position;
        float CentralCardIndex = (ActiveCards.Count / 2.0f) - 0.5f;

        for (int i = 0; i < ActiveCards.Count; i++)
        {
            ActiveCard CurrentCard = ActiveCards[i];
            Vector2 Position;
            float HalfCardWidth = Card.CARD_SIZE.x / 2;
            float Offset = (ActiveCards.Count % 2 == 0) ? HalfCardWidth : 0.0f;

            if (i < CentralCardIndex)
            {
                int CardsFromCentre = Mathf.FloorToInt(CentralCardIndex) - i;
                Position = new Vector2(CentralPosition.x - (Offset + (Card.CARD_SIZE.x * CardsFromCentre) + DISTANCE_BETWEEN_CARDS), CentralPosition.y);
            }
            else if (i > CentralCardIndex)
            {
                int CardsFromCentre = i - Mathf.CeilToInt(CentralCardIndex);
                Position = new Vector2(CentralPosition.x + (Offset + (Card.CARD_SIZE.x * CardsFromCentre) + DISTANCE_BETWEEN_CARDS), CentralPosition.y);
            }
            else
            {
                Position = CentralPosition;
            }

            CurrentCard.transform.position = Position;
        }
    }
}

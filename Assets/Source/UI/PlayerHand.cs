using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHand : List<PlayerCard>
{
    private const float DISTANCE_BETWEEN_CARDS = 2.5f;

    private GameObject HandCanvas;

    public PlayerHand(GameObject HandCanvas)
    {
        this.HandCanvas = HandCanvas;
    }

    public void PlayCard(ActiveCard Card)
    {
        this.RemoveAt(Card.Position);

        GameState.Instance.BoardManager.PlayCard(Card);

        ReshuffleCards();
    }

    public void Enqueue(PlayerCard Card)
    {
        this.Insert(0, Card);
    }

    public PlayerCard Dequeue()
    {
        PlayerCard Card = this[this.Count - 1];
        this.RemoveAt(this.Count - 1);

        return Card;
    }

    public void ReshuffleCards()
    {
        foreach (Transform Child in HandCanvas.transform)
        {
            GameObject.Destroy(Child.gameObject);
        }

        Vector2 CentralPosition = HandCanvas.transform.position;
        float CentralCardIndex = (this.Count / 2.0f) - 0.5f;
      
        for (int i = 0; i < this.Count; i++)
        {
            PlayerCard CurrentCard = this[i];
            Vector2 Position;
            float HalfCardWidth = Card.CARD_SIZE.x / 2;
            float Offset = (this.Count % 2 == 0) ? HalfCardWidth : 0.0f; 

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

            GameObject NewCard = GamePrefabs.InstantiatePrefab(GamePrefabs.Instance.CardPrefab, HandCanvas.transform);
            NewCard.name = CurrentCard.Name;
            NewCard.transform.position = Position;

            NewCard.GetComponent<ActiveCard>().Init(CurrentCard, i);
            Image CardImage = NewCard.GetComponent<Image>();
            CardImage.sprite = CurrentCard.Image;
        }
    }
}

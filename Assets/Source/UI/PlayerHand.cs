using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHand : Queue<PlayerCard>
{
    private const float DISTANCE_BETWEEN_CARDS = 2.5f;

    private GameObject HandCanvas;

    public PlayerHand(GameObject HandCanvas)
    {
        this.HandCanvas = HandCanvas;
    }

    public void ReshuffleCards()
    {
        Vector2 CentralPosition = HandCanvas.transform.position;

        PlayerCard[] HandArr = this.ToArray();
        int CentralCardIndex = Mathf.RoundToInt((HandArr.Length / 2.0f) - 0.5f);
      
        for (int i = 0; i < HandArr.Length; i++)
        {
            PlayerCard CurrentCard = HandArr[i];
            Vector2 position;

            if (i < CentralCardIndex)
            {
                int CardsFromCentre = CentralCardIndex - i;
                position = new Vector2(CentralPosition.x - ((Card.CARD_SIZE.x / 2) + (Card.CARD_SIZE.x * CardsFromCentre) + DISTANCE_BETWEEN_CARDS), CentralPosition.y);
            }
            else if (i > CentralCardIndex)
            {
                int CardsFromCentre = i - CentralCardIndex;
                position = new Vector2(CentralPosition.x + ((Card.CARD_SIZE.x / 2) + (Card.CARD_SIZE.x * CardsFromCentre) + DISTANCE_BETWEEN_CARDS), CentralPosition.y);
            }
            else
            {
                position = CentralPosition;
            }

            GameObject NewCard = new GameObject(CurrentCard.Name);
            Image Image = NewCard.AddComponent<Image>();
            Image.sprite = CurrentCard.Image;
            Image.rectTransform.sizeDelta = Card.CARD_SIZE;
            Image.transform.position = position;
            NewCard.transform.SetParent(HandCanvas.transform);
        }
    }
}

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
        foreach (Transform Child in HandCanvas.transform)
        {
            GameObject.Destroy(Child.gameObject);
        }

        Vector2 CentralPosition = HandCanvas.transform.position;

        PlayerCard[] HandArr = this.ToArray();
        float CentralCardIndex = (HandArr.Length / 2.0f) - 0.5f;
      
        for (int i = 0; i < HandArr.Length; i++)
        {
            PlayerCard CurrentCard = HandArr[i];
            Vector2 Position;
            float HalfCardWidth = Card.CARD_SIZE.x / 2;
            float Offset = (HandArr.Length % 2 == 0) ? HalfCardWidth : 0.0f; 

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

            GameObject NewCard = new GameObject(CurrentCard.Name);
            Image Image = NewCard.AddComponent<Image>();
            Image.sprite = CurrentCard.Image;
            Image.rectTransform.sizeDelta = Card.CARD_SIZE;
            Image.transform.position = Position;
            NewCard.transform.SetParent(HandCanvas.transform);
        }
    }
}

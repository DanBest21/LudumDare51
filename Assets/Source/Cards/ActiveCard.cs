using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCard : MonoBehaviour
{
    public const float SECONDS_ON_BOARD_AFTER_DISCARD = 1.5f;

    public enum ECardStatus
    {
        InHand,
        OnBoard,
        Discarding,
        Discarded
    }

    public ECardStatus CardStatus;
    public int Position;
    public PlayerCard CardInfo;

    private float DiscardTime = -1.0f;

    public void Update()
    {
        if (DiscardTime + SECONDS_ON_BOARD_AFTER_DISCARD <= Time.timeSinceLevelLoad && CardStatus == ECardStatus.Discarding)
        {
            CardStatus = ECardStatus.Discarded;

            Destroy(gameObject);
        }
    }

    public ActiveCard Init(PlayerCard CardInfo, int Position)
    {
        this.CardInfo = CardInfo;
        this.Position = Position;
        this.CardStatus = ECardStatus.InHand;

        return this;
    }

    public void PlayCard()
    {
        GameState.Instance.PlayerCardManager.Hand.PlayCard(this);

        this.CardStatus = ECardStatus.OnBoard;
    }

    public void DiscardCard()
    {
        GameState.Instance.PlayerCardManager.DiscardPile.Push(CardInfo);

        this.CardStatus = ECardStatus.Discarding;
        DiscardTime = Time.timeSinceLevelLoad;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCard : MonoBehaviour
{
    public enum ECardStatus
    {
        InHand,
        OnBoard
    }

    public ECardStatus CardStatus;
    public int Position;
    public PlayerCard CardInfo;

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
    }
}

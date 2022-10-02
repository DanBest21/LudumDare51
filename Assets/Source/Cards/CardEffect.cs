using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Effect")]
public class CardEffect : ScriptableObject
{

    public enum EEffectType
    {
        AddResource,
        DrawCard,
        DiscardCard,
        BurnCard,
        RetrieveCard,
        AddCondition,
        RemoveCondition,
        Pause,
        PeekEnemy,
        PeekDiscardEnemy,
        ShuffleEnemy,
        RetrieveEnemy,
        DiscardEnemy,
        ToDay,
        ToNight
    }

    public EEffectType Type;

    public int ReferenceID;
    public int Value;

    public void ApplyInstantEffect()
    {
        switch (Type)
        {
            case EEffectType.AddResource:
                ResourceManager.EResourceType ResourceType = (ResourceManager.EResourceType) ReferenceID;
                GameState.Instance.ResourceManager.ModifyResource(ResourceType, Value);
                break;
            case EEffectType.DrawCard:
                break;
            case EEffectType.DiscardCard:
                break;
            case EEffectType.BurnCard:
                break;
            case EEffectType.RetrieveCard:
                break;
            case EEffectType.AddCondition:
                break;
            case EEffectType.RemoveCondition:
                break;
            case EEffectType.Pause:
                break;
            case EEffectType.PeekEnemy:
                break;
            case EEffectType.PeekDiscardEnemy:
                break;
            case EEffectType.ShuffleEnemy:
                break;
            case EEffectType.RetrieveEnemy:
                break;
            case EEffectType.DiscardEnemy:
                break;
            case EEffectType.ToDay:
                break;
            case EEffectType.ToNight:
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
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

    [SerializeField]
    private EEffectType type { get; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

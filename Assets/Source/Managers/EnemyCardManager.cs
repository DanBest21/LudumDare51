using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardManager : MonoBehaviour
{
    private const int NUMBER_OF_DAY_CARDS = 15;
    private const int NUMBER_OF_NIGHT_CARDS = 15;

    private Stack<EnemyCard> DayDeck { get; } = new Stack<EnemyCard>(NUMBER_OF_DAY_CARDS);
    private Stack<EnemyCard> NightDeck { get; } = new Stack<EnemyCard>(NUMBER_OF_NIGHT_CARDS);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

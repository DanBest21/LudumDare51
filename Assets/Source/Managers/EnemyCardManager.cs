using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardManager : MonoBehaviour
{
    private const int NUMBER_OF_DAY_CARDS = 15;
    private const int NUMBER_OF_NIGHT_CARDS = 15;

    public Stack<EnemyCard> DayDeck { get; private set; } = new Stack<EnemyCard>(NUMBER_OF_DAY_CARDS);
    public Stack<EnemyCard> NightDeck { get; private set;  } = new Stack<EnemyCard>(NUMBER_OF_NIGHT_CARDS);
}

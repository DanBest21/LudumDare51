using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private const int MAXIMUM_ACTIVE_CARDS = 5;

    public List<PlayerCard> ActiveCards { get; private set; } = new List<PlayerCard>(MAXIMUM_ACTIVE_CARDS);
}

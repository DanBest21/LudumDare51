using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private const int MAXIMUM_ACTIVE_CARDS = 5;

    private List<PlayerCard> ActiveCards { get; } = new List<PlayerCard>(MAXIMUM_ACTIVE_CARDS);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

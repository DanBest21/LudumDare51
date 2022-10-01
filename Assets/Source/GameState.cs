using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Constants
    private const double ACTION_DELTA_TIME = 10.0f;

    private double NextActionTime = 10.0f;

    private List<Card> PlayerDeck { get; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= NextActionTime)
        {
            NextActionTime += ACTION_DELTA_TIME;

            // Action goes here...
        }
    }
}

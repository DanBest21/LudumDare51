using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState _instance;

    public static GameState Instance { get { return _instance; } }

    // Constants
    private const float ACTION_DELTA_TIME = 10.0f;
    private const float DRAW_DELTA_TIME = 5.0f;

    // Managers
    private PlayerCardManager PlayerCardManager = new PlayerCardManager();
    private ResourceManager ResourceManager = new ResourceManager();
    private EnemyCardManager EnemyCardManager = new EnemyCardManager();

    private float NextActionTime = ACTION_DELTA_TIME;
    private float NextDrawTime = DRAW_DELTA_TIME;

    [SerializeField]
    private List<Task> TaskQueue;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.timeSinceLevelLoad;

        if (currentTime >= NextDrawTime)
        {
            NextDrawTime += DRAW_DELTA_TIME;

            // Draw a card here...
        }

        if (currentTime >= NextActionTime)
        {
            NextActionTime += ACTION_DELTA_TIME;

            // Action goes here...
        }
    }
}

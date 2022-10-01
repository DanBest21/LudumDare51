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
    public BoardManager BoardManager { get; private set; }
    public PlayerCardManager PlayerCardManager { get; private set; }
    public ResourceManager ResourceManager { get; private set; }
    public EnemyCardManager EnemyCardManager { get; private set; }

    private float NextActionTime = ACTION_DELTA_TIME;
    private float NextDrawTime = DRAW_DELTA_TIME;

    [SerializeField]
    private Queue<Task> TaskQueue = new Queue<Task>();

    private void Awake()
    {
        BoardManager = gameObject.AddComponent<BoardManager>();
        PlayerCardManager = gameObject.AddComponent<PlayerCardManager>();
        ResourceManager = gameObject.AddComponent<ResourceManager>();
        EnemyCardManager = gameObject.AddComponent<EnemyCardManager>();

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.timeSinceLevelLoad;

        if (currentTime >= NextDrawTime)
        {
            NextDrawTime += DRAW_DELTA_TIME;

            PlayerCardManager.DrawCard();
        }

        if (currentTime >= NextActionTime)
        {
            NextActionTime += ACTION_DELTA_TIME;

            // Action goes here...
        }
    }
}

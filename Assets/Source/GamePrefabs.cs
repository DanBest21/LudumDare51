using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePrefabs : MonoBehaviour
{
    private static GamePrefabs _instance;

    public static GamePrefabs Instance { get { return _instance; } }

    public GameObject CardPrefab;

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

    public static GameObject InstantiatePrefab(GameObject Prefab, Transform ParentTransform)
    {
        return Instantiate(Prefab, ParentTransform);
    }
}

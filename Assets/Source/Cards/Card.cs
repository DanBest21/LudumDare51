using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private string Name;
    [SerializeField]
    private string Description;
    [SerializeField]
    private List<CardEffect> CardEffects;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
    }
}

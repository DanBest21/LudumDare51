using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject
{
    public static Vector2 CARD_SIZE { get; } = new Vector2(160.0f, 240.0f);

    public string Name;
    public string Description;
    public Sprite Image;
    public List<CardEffect> CardEffects;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private string Name;
    public List<CharacterCondition> Conditions { get; private set; } = new List<CharacterCondition>();
}

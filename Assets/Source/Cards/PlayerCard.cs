using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Card")]
public class PlayerCard : Card
{
    [SerializeField]
    public Character CrewMember = null;
}

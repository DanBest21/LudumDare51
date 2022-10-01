using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Range(0, 100)]
    private int CrewCount;
    [Range(0, 100)]
    private int Morale;
    [Range(0, 100)]
    private int Health;
    [Range(0, 100)]
    private int Fatigue;
    [Range(0, 100)]
    private int Supplies;
    [Range(0, 100)]
    private int Sanity;
}

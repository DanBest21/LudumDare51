using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public enum EResourceType
    {
        CrewCount, // 0
        Morale, // 1
        Health, // 2
        Fatigue, // 3
        Supplies, // 4
        Sanity, // 5
        COUNT
    }

    private Dictionary<EResourceType, int> ResourceDict = new Dictionary<EResourceType, int>((int)EResourceType.COUNT);

    private void Awake()
    {
        foreach (EResourceType ResourceType in System.Enum.GetValues(typeof(EResourceType)))
        {
            ResourceDict.Add(ResourceType, 50);
        }
    }

    public void ModifyResource(EResourceType Type, int Delta)
    {
        ResourceDict[Type] += Delta;

        // Probably some checks here to see if we're dead.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDeposit : RTSObject
{
    public Resource resource;
    public int yield;

    public ResourceDeposit()
    {
        _type = RTSObjectType.ResourceDeposit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Resource GetResource()
    {
        return resource;
    }

    public int GetYield()
    {
        return yield;
    }

    public Dictionary<Resource, int> Gather(int damage) 
    { // Outputs the resource gathered
        Dictionary<Resource, int> output = new Dictionary<Resource, int>();

        if(yield - damage <= 0) {
            output.Add(resource, yield);
            Delete();
        }
        else {
            output.Add(resource, damage);
        }

        yield -= damage;

        return output;
    }
}

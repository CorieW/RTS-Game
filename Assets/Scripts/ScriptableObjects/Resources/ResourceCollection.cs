using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollection
{
    Dictionary<Resource, int> _resources = new Dictionary<Resource, int>();

    public ResourceCollection() 
    {
        _resources.Add(Resource.Food, 0);
        _resources.Add(Resource.Wood, 0);
        _resources.Add(Resource.Stone, 0);
        _resources.Add(Resource.Gold, 0);
    }

    public Dictionary<Resource, int> GetResources(Resource resource) 
    {
        return _resources;
    }

    public int GetResourceQuantity(Resource resource) 
    {
        return _resources[resource];
    }

    int AddResource(Resource resource, int quantity) 
    { // Returns the new resource quantity
        _resources[resource] += quantity;
        return _resources[resource];
    }

    public Dictionary<Resource, int> AddResources(Dictionary<Resource, int> resources) 
    { // Returns the new resources
        foreach(Resource resource in resources.Keys) 
        {
            AddResource(resource, resources[resource]);
        }
        return _resources;
    }

    int TakeResource(Resource resource, int quantity) 
    { // Returns the new resource quantity
        _resources[resource] -= quantity;
        return _resources[resource];
    }

    public Dictionary<Resource, int> TakeResource(Dictionary<Resource, int> resources) 
    { // Returns the new resources
        foreach(Resource resource in resources.Keys) 
        {
            TakeResource(resource, resources[resource]);
        }
        return _resources;
    }
}
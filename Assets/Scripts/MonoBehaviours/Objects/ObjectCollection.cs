using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollection {
    List<RTSObject> _objects = new List<RTSObject>();

    public List<RTSObject> AddObject(RTSObject obj)
    {
        _objects.Add(obj);
        return _objects;
    }

    public List<RTSObject> RemoveObject(RTSObject obj)
    {
        _objects.Remove(obj);
        return _objects;
    }

    public List<RTSObject> ClearObjects()
    {
        _objects.Clear();
        return _objects;
    }

    public List<Unit> GetUnits() 
    { // Returns all of the units in the _objects list
        List<Unit> units = new List<Unit>();

        foreach(RTSObject obj in _objects) {
            Unit unit = obj as Unit;

            if(unit) {
                units.Add(unit);
            }
        }

        return units;
    }

    public List<Building> GetBuildings() 
    { // Returns all of the buildings in the _objects list
        List<Building> buildings = new List<Building>();

        foreach(RTSObject obj in _objects) {
            Building building = obj as Building;

            if(building) {
                buildings.Add(building);
            }
        }

        return buildings;
    }
}
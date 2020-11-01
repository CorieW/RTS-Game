using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObjects {
    public ClientHandler clientHandler;
    public List<RTSObject> selectedObjs = new List<RTSObject>();

    public SelectedObjects(ClientHandler clientHandler) 
    {
        this.clientHandler = clientHandler;
    }

    public void Select(RTSObject[] objs) 
    {
        foreach (RTSObject obj in objs)
        {
            selectedObjs.Add(obj);
        }
    }

    public void Reselect(RTSObject[] objs) 
    {
        selectedObjs.Clear();
        foreach (RTSObject obj in objs)
        {
            selectedObjs.Add(obj);
        }
    }

    public void Deselect(RTSObject[] objs) 
    {
        foreach (RTSObject obj in objs)
        {
            selectedObjs.Remove(obj);
        }
    }

    public void Unselect() 
    {
        selectedObjs.Clear();
    }

    public void AssignTask(OrderAction action, Task task) 
    { // Set / Give a unit a task
        foreach(RTSObject selectedObj in selectedObjs) {
            Unit selectedUnit = selectedObj as Unit;

            // Selected object is a unit and can be controlled by client player
            if(selectedUnit && selectedUnit.CanControl(clientHandler.player)) {
                switch(action) {
                    case OrderAction.Singular:
                        selectedUnit.tasks.SetTask(task);
                        break;
                    case OrderAction.Additive:
                        selectedUnit.tasks.AssignTask(task);
                        break;
                }
            }
        }
    }

    public void Delete()
    { // Deletes all of the selected units and buildings
        foreach(RTSObject selectedObj in selectedObjs) {
            if(selectedObj is Unit || selectedObj is Building) {
                selectedObj.Delete();
            }
        }
    }

    public bool Contains(RTSObject obj) 
    { // Checks whether or not the object is selected
        return selectedObjs.Contains(obj);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandler : MonoBehaviour
{
    // Dependencies
    public BattleHandler battleHandler;

    [Space]

    public Player player;
    public SelectedObjects selectedObjects;

    void Awake() {
        selectedObjects = new SelectedObjects(this);

        if(battleHandler == null) battleHandler = FindObjectOfType<BattleHandler>();
    }

    void Start()
    {
        //* Gets the client player as the client player is always 1st in the players array.
        //* However, this is likely not to be the case in the online version.
        player = battleHandler.GetPlayer(0);
    }

    void Update()
    {
        Vector3 pos;
        RaycastHit2D hit;
        RTSObject[] hits = null;

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);

            hit = Physics2D.Raycast(pos, -Vector2.zero);
            RTSObject rtsHit = null;
            if(hit)
                rtsHit = hit.transform.GetComponent<RTSObject>();

            if(rtsHit)
                hits = new RTSObject[1] { rtsHit }; // Objects that were clicked / were included in the selection box
        }

        // Select, Reselect, Deselect, and Unselect Orders
        if(hits != null && Input.GetMouseButtonDown(0)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                if (hits.Length == 1 && selectedObjects.Contains(hits[0])) {
                    onDeselectOrder(hits);
                }
                else {
                    onSelectOrder(hits);
                }
                return;
            }
            onReselectOrder(hits);
            return;
        }
        else if (hits == null && Input.GetMouseButtonDown(0)) {
            onUnselectOrder();
            return;
        }
        
        // Move, Build, Gather, and Attack Orders
        if(hits != null && Input.GetMouseButtonDown(1)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                switch(hits[0].GetRTSObjectType()) {
                    case RTSObjectType.ResourceDeposit:
                        onGatherOrder(OrderAction.Additive, hits[0] as ResourceDeposit);
                        break;
                }
            }
            else {
                switch(hits[0].GetRTSObjectType()) {
                    case RTSObjectType.ResourceDeposit:
                        onGatherOrder(OrderAction.Singular, hits[0] as ResourceDeposit);
                        break;
                }
            }
            return;
        } 
        else if (hits == null && Input.GetMouseButtonDown(1)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                onMoveOrder(OrderAction.Additive);
            }
            else {
                onMoveOrder(OrderAction.Singular);
            }
            return;
        }

        if (Input.GetKey(KeyCode.Delete))
        {
            onDeleteOrder();
        }
    }

    public void onSelectOrder(RTSObject[] objs) 
    { // Selected a new object for the current selection
        selectedObjects.Select(objs);
    }

    public void onReselectOrder(RTSObject[] objs) 
    { // New objects were selected
        selectedObjects.Reselect(objs);
    }

    public void onDeselectOrder(RTSObject[] objs)
    { // Deselected a objects that were selected
        selectedObjects.Deselect(objs);
    }

    public void onUnselectOrder()
    { // Unselects all of the selected objects
        selectedObjects.Unselect();
    }

    public void onMoveOrder(OrderAction action)
    {
        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);

        selectedObjects.AssignTask(action, new MoveTask(pos));
    }

    public void onBuildOrder(OrderAction action, Building building) 
    {
        selectedObjects.AssignTask(action, new BuildTask(building));
    }

    public void onGatherOrder(OrderAction action, ResourceDeposit resource) 
    {
        selectedObjects.AssignTask(action, new GatherTask(resource));
    }

    public void onAttackOrder(OrderAction action, RTSObject obj) 
    {
        selectedObjects.AssignTask(action, new AttackTask(obj));
    }

    public void onDeleteOrder()
    {
        selectedObjects.Delete();
    }
}
public enum OrderAction {
    Singular, Additive
}
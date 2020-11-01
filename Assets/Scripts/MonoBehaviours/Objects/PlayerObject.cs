using UnityEngine;

public abstract class PlayerObject : RTSObject {
    public Player owner;

    void Awake() 
    {
        if (!owner)
        { // Attempt to find the owner if one is not provided
            GameObject parent = transform.parent ? transform.parent.gameObject : null;
            Player player = parent ? parent.GetComponent<Player>() : null;
            if (player) SetOwner(player);
            else Debug.LogError("Could not find an object's owner."); // TODO: Handle error properly
        }
    }

    private void SetOwner(Player player) 
    {
        owner = player;
    }

    public Player GetOwner() 
    {
        return owner;
    }

    public bool CanControl(Player player) 
    { // Returns whether or not the player can control the object
        return player == owner;
    } 
}
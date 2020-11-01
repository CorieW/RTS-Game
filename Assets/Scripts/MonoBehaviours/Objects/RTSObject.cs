using UnityEngine;

public abstract class RTSObject : MonoBehaviour {
    protected RTSObjectType _type;

    protected void Start() 
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y);
    }

    public RTSObjectType GetRTSObjectType() 
    {
        return _type;
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
public enum RTSObjectType {
    Unit, Building, ResourceDeposit
}
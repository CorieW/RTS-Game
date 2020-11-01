using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {
    public static Vector3 CorrectPosition(Vector3 position) 
    {
        return new Vector3(position.x, position.y, position.y);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public Player[] players;

    void Awake()
    {

    }

    void Start() 
    {

    }

    void Update()
    {
        
    }

    public Player[] GetPlayers() {
        return players;
    }

    public Player GetPlayer(int index) {
        return players[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public GameAgent ShipAgent;

    private void Awake()
    {
        if (ShipAgent == null)
        {
            ShipAgent = GetComponent<GameAgent>();
        }
    }
}

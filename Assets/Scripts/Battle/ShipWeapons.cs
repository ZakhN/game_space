using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public SpaceShip _SpaceShip;
    private void Awake()
    {
        if (_SpaceShip == null)
        {
            _SpaceShip = GetComponentInParent<SpaceShip>();
        }
    }
}

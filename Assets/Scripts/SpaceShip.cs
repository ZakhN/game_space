using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kosmos6
{
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
}
using UnityEngine;

namespace Kosmos6
{
    public class GameAgent : MonoBehaviour
    {
        public enum Fraction
        {
            Player,
            Allies,
            SevenStart
        }

        public Fraction ShipFraction;
    }
}
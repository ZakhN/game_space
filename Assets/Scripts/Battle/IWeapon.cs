using UnityEngine;

namespace Kosmos6
{
    public interface IWeapon
    {
        public Vector3 FireWeapon(Vector3 targetPosition);
        void VisualizeFiring(Vector3 targetPosition);
        public void Damage(float damageAmount, Vector3 targetHitPosition, GameAgent sender);
    }
}
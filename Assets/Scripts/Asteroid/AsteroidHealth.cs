using UnityEngine;

namespace Kosmos6
{
    public class AsteroidHealth : MonoBehaviour, IDamageable
    {
        public float Health { get; set; }
        [SerializeField] private GameObject PrefabEffectDestr;
        [SerializeField] private GameObject PrefabAsteroidDivision;
        public bool Destroyed;
        public int DivisionCounter = 2;

        public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
        {
            Health -= damageAmount;
            if (Health <= 0 && !Destroyed)
            {
                if (PrefabEffectDestr)
                {
                    Instantiate(PrefabEffectDestr, transform.position, Quaternion.identity);
                }

                if (PrefabAsteroidDivision != null && DivisionCounter > 0)
                {
                    Vector3 Shard1Pos = new Vector3(
                        transform.position.x + Random.Range(-0.1f, 0.1f),
                        transform.position.y + Random.Range(-0.1f, 0.1f),
                        transform.position.z + Random.Range(-0.1f, 0.1f)
                    );
                    Vector3 Shard2Pos = new Vector3(
                        transform.position.x + Random.Range(-0.1f, 0.1f),
                        transform.position.y + Random.Range(-0.1f, 0.1f),
                        transform.position.z + Random.Range(-0.1f, 0.1f)
                    );

                    var s1 = Instantiate(PrefabAsteroidDivision, Shard1Pos + PrefabAsteroidDivision.transform.localScale, Quaternion.identity);
                    var s2 = Instantiate(PrefabAsteroidDivision, Shard2Pos - PrefabAsteroidDivision.transform.localScale, Quaternion.identity);

                    s1.GetComponent<AsteroidHealth>().DivisionCounter = DivisionCounter - 1;
                    s2.GetComponent<AsteroidHealth>().DivisionCounter = DivisionCounter - 1;
                }

                ManagerScore.Instance.AddScore(1);

                Destroyed = true;
                Destroy(gameObject);
            }
        }

        public void ReceiveHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
        {
            throw new System.NotImplementedException();
        }
    }
}
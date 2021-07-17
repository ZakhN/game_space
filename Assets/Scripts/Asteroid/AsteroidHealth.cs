using UnityEngine;

public class AsteroidHealth : MonoBehaviour, IDamageable
{
    public float Health { get; set; }
    [SerializeField] private GameObject PrefabEffectDestr;
    public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            if (PrefabEffectDestr)
            {
                Instantiate(PrefabEffectDestr, transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }

    public void ReceiveHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

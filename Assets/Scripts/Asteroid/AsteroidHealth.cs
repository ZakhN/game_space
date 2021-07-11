using UnityEngine;

public class AsteroidHealth : MonoBehaviour, IDamageable
{
    public float Health { get; }

    public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
    {
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

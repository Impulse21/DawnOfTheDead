using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    public uint impactDamage;
    public int damageFalloffRate;
    public uint damageRadius;
    public uint criticalDamageRadius;

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
        {
            if (explosion == null)
            {
                return;
            }

            Explode();
        }
    }

    void Explode()
    {
        GameObject explosionInstace = Instantiate(explosion, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    void DealAreaDamage()
    {
        var colls = Physics2D.OverlapCircleAll(transform.position, damageRadius, LayerMask.GetMask("Shootable"), -1);

        foreach(var col in colls)
        {
            if(col.gameObject.tag.Equals("Enemy"))
            {
                var distance = Vector2.Distance(col.transform.position, transform.position);
                //var damage = (dist)
            }
        }
        
    }
}

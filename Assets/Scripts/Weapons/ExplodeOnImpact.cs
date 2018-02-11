using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    // Tags to explode on
    public List<string> explodeTags = new List<string>();     

    public uint impactDamage;

    // Explosion does damage
    public bool doesDamage = true;              
    public float damageRadius;

    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (explodeTags.Contains(coll.gameObject.tag) || coll.gameObject.tag == ("Wall"))
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
        DealAreaDamage();
        gameObject.SetActive(false);
    }

    /**
     * The damage calculation is as follows:
     *      DeltaDamage = BaseDamage - (BaseDamage * [ Distance / Radius ]);
     */
    void DealAreaDamage()
    {
        var colls = Physics2D.OverlapCircleAll(transform.position, damageRadius, LayerMask.GetMask("Shootable"), -1);

        foreach(var col in colls)
        {
            if(explodeTags.Contains(col.gameObject.tag))
            {
                var distance = Vector2.Distance(col.transform.position, transform.position);

                int damage = (int) (impactDamage -  impactDamage * (distance / damageRadius));

                IDamageable enemy = col.gameObject.GetComponent<IDamageable>();

                if(enemy != null)
                {
                    Debug.Log("Explosion has hit someone");
                    enemy.TakeDamage(damage);
                }
                else
                {
                    Debug.Log("The collided shootable object does not implement damage interface");
                }
            }
        }
    }
}

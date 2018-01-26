using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
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
}

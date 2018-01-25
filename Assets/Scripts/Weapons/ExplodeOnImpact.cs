using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour 
{
	public GameObject explosion;
	public uint lifespan = 3;

	 bool explode;

	 void OnCollisionEnter2D(Collision2D coll) 
	 {
		 if(coll.gameObject.tag !=  "Player")
		 {
			 if(explosion == null)
			 {
				 return;
			 }
			 
			 Explode();
		 }
	 }

	 void Explode()
	 {
		 Debug.Log("Exploding");
		 GameObject explodeObj = Instantiate(explosion, transform.position, transform.rotation);
		 gameObject.SetActive(false);

		 Destroy(explodeObj, lifespan);
	 }
}

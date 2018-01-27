using UnityEngine;

public class CleanUpOnAnimationFinsh : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (animator != null)
        {
            CleanUpOnAnimationFinished();
        }
    }
    void CleanUpOnAnimationFinished()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Done"))
        {
            Destroy(gameObject);
        }
    }

}

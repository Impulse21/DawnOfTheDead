using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;          // Reference to the player
    
    private Vector3 cameraZOffet;      // Camera Z offest, used make sure the camera can see the player

    void Start()
    {
        cameraZOffet = new Vector3(0.0f, 0.0f, transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + cameraZOffet;
    }
}

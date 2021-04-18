
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField] Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField] float smooth_velocity = 0.125f;
    
    void FixedUpdate() {   
        Vector3 desiredPosition = player.position + offset;
        desiredPosition.z = transform.position.z;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smooth_velocity);
        Debug.Log(smoothPosition);
        transform.position = smoothPosition;
    }
}

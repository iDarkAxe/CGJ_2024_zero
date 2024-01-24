using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + posOffset, ref velocity, timeOffset);
    }
}

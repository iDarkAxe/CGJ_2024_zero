using UnityEngine;

public class LanternMovement : MonoBehaviour
{
    public bool isFacingLeft = true;

    private bool previousFacingDirection = false;
    private float currentTime, previousTime;
    private bool stateAnimation = false;
    private Transform player;

    public float animationSpeed = 0.7f;
    public float animationAmplitude = 0.015f;
    public float offsetX = 0.3f;    // offsets to adjust position to player's hands (graphically)
    public float offsetY = 0;

    public SpriteRenderer Graphics; // to show/hide lantern

    void Start()
    {
        player = PlayerMovement.instance.transform;
        transform.parent = player;        // follow player by making latern its child
        isFacingLeft = PlayerMovement.instance.spriteRenderer.flipX;    //TODO : get player's direction
        FlipLantern();
    }

    void FixedUpdate()
    {
        isFacingLeft = PlayerMovement.instance.spriteRenderer.flipX;    //TODO : get player's direction

        currentTime = Time.time;
        if(currentTime > previousTime+animationSpeed)   // up and down "levitating" movement of lantern
        {
            previousTime = currentTime;
            if(stateAnimation) {
                transform.position += new Vector3(0, animationAmplitude);
            } else {
                transform.position += new Vector3(0, -animationAmplitude);
            }
            stateAnimation = !stateAnimation;
        }

        if(isFacingLeft != previousFacingDirection) {   // direction changed, so move lantern
            FlipLantern();
            previousFacingDirection = isFacingLeft;
        }
    }
    private void FlipLantern(){
        transform.position = player.position; // center lantern, then move it
        transform.position += new Vector3(0, offsetY);
        if(isFacingLeft) {
            transform.position += new Vector3(-offsetX, 0);
        } else {
            transform.position += new Vector3(offsetX, 0);
        }
    }
}

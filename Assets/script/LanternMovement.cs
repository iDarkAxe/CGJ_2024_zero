using UnityEngine;

public class LanternMovement : MonoBehaviour
{
    public bool isFacingLeft = true;
    public bool isPickedUp = true;  // player should start without it

    private bool previousFacingDirection;
    private float currentTime, previousTime;
    private bool stateAnimation = false;
    private GameObject player;

    public float animationSpeed = 0.7f;
    public float animationAmplitude = 0.015f;
    public float offsetX = 0.3f;    // offsets to adjust position to player's hands (graphically)
    public float offsetY = 0;

    public SpriteRenderer Graphics; // to show/hide lantern

    public static PlayerMovement instance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.parent = player.transform;    // follow player by making latern its child
        previousFacingDirection = !isFacingLeft;    // init this boolean 
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
            transform.position = player.transform.position; // center lantern, then move it
            transform.position += new Vector3(0, offsetY);
            if(isFacingLeft) {
                transform.position += new Vector3(-offsetX, 0);
            } else {
                transform.position += new Vector3(offsetX, 0);
            }
        previousFacingDirection = isFacingLeft;
        }

        if(isPickedUp) {    // hide lantern in the beginning, player hasnt picked it up (hhihihih)
            Graphics.enabled = true;
        } else {
            Graphics.enabled = false;
        }
    }
}

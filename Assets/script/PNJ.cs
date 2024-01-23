using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    public Text interactText, message1, message2;
    public GameObject dialogueBox;
    public BoxCollider2D reaperCollider;
    public Animator reaperAnimation;
    private bool isInRange = false;
    private int stateDialogue = 0;
    public GameObject lantern;
    public GameObject lanternOnGround;


    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && isInRange){
            //get lantern
            switch (stateDialogue)
            {
                case 0:
                    
                    PlayerMovement.instance.enabled = false;
                    PlayerMovement.instance.rb.velocity = Vector3.zero;
                    PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
                    dialogueBox.SetActive(true);
                    stateDialogue = 1;
                    break;
                case 1:
                    message1.enabled = false;
                    message2.enabled = true;
                    stateDialogue = 2;
                    break;
                case 2:
                    dialogueBox.SetActive(false);
                    Inventory.instance.collectLantern = true;
                    PlayerMovement.instance.enabled = true;
                    PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
                    reaperCollider.enabled = false;
                    lantern.SetActive(true);
                    Destroy(lanternOnGround);
                    break;
            }
            
        }


        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            interactText.enabled = true;
            isInRange = true;
            reaperAnimation.SetTrigger("isPlayerNear");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            interactText.enabled = false;
            isInRange = false;
            reaperAnimation.SetTrigger("isPlayerFar");
        }
    }
}


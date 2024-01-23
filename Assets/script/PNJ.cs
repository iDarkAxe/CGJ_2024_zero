using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    public Text interactText, message1, message2;
    public GameObject dialogueBox;
    public BoxCollider2D reaperCollider;
    private bool isInRange = false;
    private int stateDialogue = 0;


    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && isInRange){
            //get lantern
            switch (stateDialogue)
            {
                case 0:
                    PlayerMovement.instance.enabled = false;
                    PlayerMovement.instance.velocity = Vector3.zero;
                    Time.timeScale = 0;
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
                    Time.timeScale = 1;
                    reaperCollider.enabled = false;
                    break;
            }
            
        }


        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            interactText.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            interactText.enabled = false;
            isInRange = false;
        }
    }
}


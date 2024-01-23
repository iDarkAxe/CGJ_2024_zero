using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectLimitTuto : MonoBehaviour
{
    public Text nonFinishTuto1, nonFinishTuto2, FinishTuto;
    public Collider2D[] wallColliders;
    public float delayBeforeEndHelpMessage = 2f, delayBetweenHelpMessage = 0.5f, destroyDelay = 2;
    private bool isSpeaking = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(Inventory.instance.collectLantern){
                FinishTuto.enabled = true;
                isSpeaking = true;
                foreach (var item in wallColliders)
                {
                    item.enabled = false;
                }
                StartCoroutine(DestroyDelayForWall());
            }
            else
            {
                if(!isSpeaking){
                    isSpeaking = true;
                    nonFinishTuto1.enabled = true;
                    StartCoroutine(DelayBeforeEndHelpMessage());
                }
                
            }
        }
    }
    public IEnumerator DelayBeforeEndHelpMessage(){
        yield return new WaitForSeconds(delayBeforeEndHelpMessage);
        nonFinishTuto1.enabled = false;
        yield return new WaitForSeconds(delayBetweenHelpMessage);
        nonFinishTuto2.enabled = true;
        yield return new WaitForSeconds(delayBeforeEndHelpMessage);
        nonFinishTuto2.enabled = false;
        isSpeaking = false;
    }
        public IEnumerator DestroyDelayForWall()
    {
      yield return new WaitForSeconds(destroyDelay);
      FinishTuto.enabled = false;
      Destroy(gameObject);
    }
}

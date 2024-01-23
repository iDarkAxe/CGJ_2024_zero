using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectLimitTuto : MonoBehaviour
{
    public Text nonFinishTuto1, nonFinishTuto2;
    private float delayBeforeEndHelpMessage = 1.5f;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(Inventory.instance.collectLantern){
                Destroy(this);
            }
            else
            {
                nonFinishTuto1.enabled = true;
                StartCoroutine(DelayBeforeEndHelpMessage());
            }
        }
    }
    public IEnumerator DelayBeforeEndHelpMessage(){
        yield return new WaitForSeconds(delayBeforeEndHelpMessage);
        nonFinishTuto1.enabled = false;
        yield return new WaitForSeconds(0.3f);
        nonFinishTuto2.enabled = true;
        yield return new WaitForSeconds(delayBeforeEndHelpMessage);
        nonFinishTuto2.enabled = false;
    }
}

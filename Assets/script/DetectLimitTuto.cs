using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectLimitTuto : MonoBehaviour
{
    public Text nonFinishTuto;
    private float delayBeforeEndHelpMessage = 3;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(Inventory.instance.collectLantern){
                Destroy(this);
            }
            else
            {
                nonFinishTuto.enabled = true;
                StartCoroutine(DelayBeforeEndHelpMessage());
            }
        }
    }
    public IEnumerator DelayBeforeEndHelpMessage(){
        yield return new WaitForSeconds(delayBeforeEndHelpMessage);
        nonFinishTuto.enabled = false;
    }
}

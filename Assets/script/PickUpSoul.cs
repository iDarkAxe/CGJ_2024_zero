using UnityEngine;
using System.Collections;

public class PickUpSoul : MonoBehaviour
{
    public SpriteRenderer Graphics;
    public Collider2D SoulCollider;
    public SoulAudioManagement audioScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Inventory.instance.AddSouls(1);
            audioScript.PlayPickUpSound();
            Graphics.enabled = false;
            SoulCollider.enabled = false;
            StartCoroutine(DestroyDelayForSound(2f));
        }
    }

    public IEnumerator DestroyDelayForSound(float destroyDelay)
    {
      yield return new WaitForSeconds(destroyDelay);
      Destroy(gameObject);
    }
}

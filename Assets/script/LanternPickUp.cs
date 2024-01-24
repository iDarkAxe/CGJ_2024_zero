using UnityEngine;

public class LanternPickUp : MonoBehaviour
{
    public GameObject lantern;

    void Start()
    {
        lantern.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            lantern.SetActive(true);
            Destroy(gameObject);
        }
    }
}

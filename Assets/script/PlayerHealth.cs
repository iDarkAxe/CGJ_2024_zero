using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    [SerializeField]
    private int health;
    private bool isInvicible = false;
    public float InvincibilityFlashDelay = 0.3f;
    public float InvincibilityTimeAfterHit = 3f;
    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public GameObject gameOverPanel;


    public static PlayerHealth instance;

    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }
        instance = this;
        health = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            TakeDamage(1);
        }
    }


    public void TakeDamage(int damage){
        if(!isInvicible){
        health -= damage;
        healthBar.SetHealth(health);
        if(health <= 0){
            GameOver();
            return;
        }
        isInvicible = true;
        StartCoroutine(InvincibilityFlash());
        StartCoroutine(HandleInvincibilityDelay());
        }
    }

    private void GameOver(){
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
        graphics.enabled = false;
        gameOverPanel.SetActive(true);
    }
    public IEnumerator InvincibilityFlash(){
    while(isInvicible){
        graphics.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(InvincibilityFlashDelay);
        graphics.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(InvincibilityFlashDelay);
    }
    }

    public IEnumerator HandleInvincibilityDelay(){
        yield return new WaitForSeconds(InvincibilityTimeAfterHit);
        isInvicible = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] healthBar;

    public void SetHealth(int health)
    {
        if((health < 5) || (health > 0))
        {
            return;
        }
        for(int i = 0; i < 5; i++)
        {
            Debug.Log("cc");
            if(i< health)
            {
                healthBar[i].enabled = true;
            }    
            else{
                healthBar[i].enabled = false;
            }
        }
    }
}
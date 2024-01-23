using UnityEngine;
using UnityEngine.UI;   // pour accéder au texte

public class Inventory : MonoBehaviour
{
    public int soulsCount;
    public bool collectLantern = false;
    //public Text coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a + d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    public void AddSouls(int count)
    {
        soulsCount += count;
        //coinsCountText.text = coinsCount.ToString();
    }
}

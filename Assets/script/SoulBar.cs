using UnityEngine;
using UnityEngine.UI;

public class SoulBar : MonoBehaviour
{

    public Slider slider;
    public int maxSouls = 10;

    private void Start()
    {
        slider.maxValue = maxSouls;
        slider.value = 0;
    }

    public void SetSoul(int soul)
    {
        slider.value = soul;
    }

}

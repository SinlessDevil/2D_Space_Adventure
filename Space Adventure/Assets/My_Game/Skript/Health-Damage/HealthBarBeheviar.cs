using UnityEngine.UI;
using UnityEngine;

public class HealthBarBeheviar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color Hight;
    public int healthValue;

    private void Start()
    {
        Slider.value = healthValue;
    }

    public void SetHealth(float health, float maxHealth)
    {      
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, Hight, Slider.normalizedValue);
    }
}

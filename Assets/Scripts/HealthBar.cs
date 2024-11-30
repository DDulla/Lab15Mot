using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerData playerData;

    void Update()
    {
        healthSlider.value = playerData.health;
    }
}


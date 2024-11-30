using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public Button redButton;
    public Button blueButton;
    public PlayerController playerController;

    void Start()
    {
        redButton.onClick.AddListener(() => ChangeColor(Color.red));
        blueButton.onClick.AddListener(() => ChangeColor(Color.blue));
    }

    void ChangeColor(Color newColor)
    {
        playerController.gameObject.GetComponent<SpriteRenderer>().color = newColor;
        playerController.currentColor = newColor; 
    }
}



using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScreen : MonoBehaviour
{
    public TMP_Text timeText;

    void Start()
    {
        float timePlayed = PlayerPrefs.GetFloat("Time");
        int minutes = Mathf.FloorToInt(timePlayed / 60);
        int seconds = Mathf.FloorToInt(timePlayed % 60);
        timeText.text = string.Format("Tiempo sobrevivido: {0:00}:{1:00}", minutes, seconds);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("GameScene");
    }
}

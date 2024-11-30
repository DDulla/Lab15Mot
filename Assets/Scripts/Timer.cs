using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float timeElapsed;
    private PlayerController playerController;

    void Start()
    {
        timeElapsed = 0f;
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (playerController.IsAlive())
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay(timeElapsed);
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetTimeElapsed()
    {
        return timeElapsed;
    }
}

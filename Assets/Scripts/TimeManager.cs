using System;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float secondsPerDay = 1f;
    [SerializeField] private TextMeshProUGUI dateText;
    private DateTime currentDate = new DateTime(2026, 1, 1);
    private float timer;
    private bool timeStopped;
    private float gameSpeed = 1;

    private void Start()
    {
        timeStopped = true;
    }

    void Update()
    {
        if (timeStopped == true) return;

        timer += Time.deltaTime * gameSpeed;
        if (timer >= secondsPerDay)
        {
            timer -= secondsPerDay;
            currentDate = currentDate.AddDays(1);

            if (dateText != null)
            {
                dateText.text = currentDate.ToString("yyyy. MM. dd.");
            }
        }
    }//Update

    public void StopDate()
    {
        timeStopped = true;
    }

    public void StartDate()
    {
        timeStopped = false;
    }

    public void SpeedUpTime()
    {
        if (gameSpeed < 6)
        {
            Debug.Log($"Před SpeedUp: {gameSpeed}");
            gameSpeed += 1;
            Debug.Log($"Po SpeedUp: {gameSpeed}");
        }
        else { return; }
    }

    public void SlowDownTime()
    {
        if (gameSpeed > 1)
        {
            Debug.Log($"Před SlowDown: {gameSpeed}");
            gameSpeed -= 1;
            Debug.Log($"po SlowDown: {gameSpeed}");
        }
        else { return; }
    }
}

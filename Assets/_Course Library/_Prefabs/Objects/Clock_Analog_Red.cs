using UnityEngine;
using System;

public class Clock_Analog_Red : MonoBehaviour
{
    [SerializeField] private Transform Clock_Analog_A_Hour;
    [SerializeField] private Transform Clock_Analog_A_Minute;
    [SerializeField] private Transform Clock_Analog_A_Second;

    [SerializeField] private bool smoothMovement = true;

    private const float degreesPerHour = 360f / 12f;
    private const float degreesPerMinute = 360f / 60f;
    private const float degreesPerSecond = 360f / 60f;

    void Start()
    {
        
    }

    void Update()
    {
        DateTime currentTime = DateTime.Now;

        float hours;
        float minutes;
        float seconds;

        if (smoothMovement)
        {
            seconds = currentTime.Second + (currentTime.Millisecond / 1000f);
            minutes = currentTime.Minute + (seconds / 60f);
            hours = (currentTime.Hour % 12) + (minutes / 60f);
        }
        else
        {
            seconds = currentTime.Second;
            minutes = currentTime.Minute;
            hours = currentTime.Hour % 12;
        }

        // Rotate the clock hands
        Clock_Analog_A_Hour.localRotation =
            Quaternion.Euler(0f, 0f, -hours * degreesPerHour);

        Clock_Analog_A_Minute.localRotation =
            Quaternion.Euler(0f, 0f, -minutes * degreesPerMinute);

        Clock_Analog_A_Second.localRotation =
            Quaternion.Euler(0f, 0f, -seconds * degreesPerSecond);
    }
}
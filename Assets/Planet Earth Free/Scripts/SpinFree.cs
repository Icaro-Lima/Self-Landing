using UnityEngine;

public class SpinFree : MonoBehaviour
{
    readonly float AngularSpeedPerHour = 15;

    float StartTime;

    void Start()
    {
        StartTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        float timeInHours = (Time.realtimeSinceStartup - StartTime) / 3600;

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, timeInHours * AngularSpeedPerHour, transform.localEulerAngles.z);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterService : MonoBehaviour
{
    public float TargetForceMultiplier;

    Rigidbody RocketRigidbody;

    float ActualForceMultiplier;
    readonly float MaxForce = 65.4f;
    readonly float ForceMultiplierAcceleration = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        ActualForceMultiplier = 0;
        TargetForceMultiplier = 0;
        RocketRigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            TargetForceMultiplier += 0.01f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            TargetForceMultiplier -= 0.01f;
        }
        TargetForceMultiplier = Mathf.Clamp01(TargetForceMultiplier);

        UpdateForce();
    }

    void UpdateForce()
    {
        ActualForceMultiplier += Mathf.Clamp(TargetForceMultiplier - ActualForceMultiplier, -ForceMultiplierAcceleration, ForceMultiplierAcceleration);
        ActualForceMultiplier = Mathf.Clamp01(ActualForceMultiplier);

        RocketRigidbody.AddForceAtPosition(transform.forward * ActualForceMultiplier * MaxForce * Time.deltaTime, transform.position);
    }
}

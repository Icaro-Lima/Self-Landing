using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody Rigidbody;

    public float ItsGravity;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ItsGravity = CompGravity();

        Rigidbody.AddForce((Vector3.zero - Rigidbody.transform.position).normalized * CompGravity(), ForceMode.Acceleration);
    }

    float CompGravity()
    {
        const float gEarth = 9.8f;
        const float rEarth = 1500;

        float sqrDistFromCenter = Rigidbody.worldCenterOfMass.sqrMagnitude;

        return gEarth * Mathf.Pow(rEarth, 2) / sqrDistFromCenter;
    }
}

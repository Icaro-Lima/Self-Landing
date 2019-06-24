using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityService : MonoBehaviour
{
    Rigidbody Rigidbody;

    float _gEarth = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody.AddForce((Vector3.zero - Rigidbody.transform.position).normalized * CompGravity(), ForceMode.Acceleration);
    }

    float CompGravity()
    {
        const float rEarth = 1500;

        float sqrDistFromCenter = Rigidbody.worldCenterOfMass.sqrMagnitude;

        return _gEarth * rEarth * rEarth / sqrDistFromCenter;
    }

    public float CompNormalizedGravity()
    {
        return CompGravity() / _gEarth;
    }
}

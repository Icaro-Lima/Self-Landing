using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityService : MonoBehaviour
{
    Rigidbody2D Rigidbody;

    float _gEarth = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody.AddForce((-Rigidbody.position).normalized * CompGravity());
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

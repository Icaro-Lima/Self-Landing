using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdGasThrusterService : MonoBehaviour
{
    public ParticleSystem ThrusterUp;
    public ParticleSystem ThrusterDown;
    public ParticleSystem ThrusterBackward;
    public ParticleSystem ThrusterRight;
    public ParticleSystem ThrusterLeft;

    Rigidbody RocketRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        RocketRigidBody = GetComponentInParent<Rigidbody>();
    }

    public void Right()
    {
        ThrusterRight.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterRight.transform.forward, ThrusterRight.transform.position);
    }

    public void Left()
    {
        ThrusterLeft.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterLeft.transform.forward, ThrusterLeft.transform.position);
    }

    public void Up()
    {
        ThrusterUp.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterUp.transform.forward, ThrusterUp.transform.position);
    }

    public void Down()
    {
        ThrusterDown.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterDown.transform.forward, ThrusterDown.transform.position);
    }
}

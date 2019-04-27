using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCenterOfMass : MonoBehaviour
{
    public Transform CenterOfMassTransform;

    Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.centerOfMass = CenterOfMassTransform.localPosition;
    }
}

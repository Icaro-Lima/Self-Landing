using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour
{
    Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();

        Rigidbody.AddForce(transform.up * 4500, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

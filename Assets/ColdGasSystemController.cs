using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdGasSystemController : MonoBehaviour
{
    Rigidbody RocketRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        RocketRigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

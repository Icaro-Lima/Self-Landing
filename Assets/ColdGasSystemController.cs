using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdGasSystemController : MonoBehaviour
{
    public ColdGasThrusterService[] ColdGasThrusterServices;

    Rigidbody RocketRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        RocketRigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad7))
        {
            ColdGasThrusterServices[0].Left();
            ColdGasThrusterServices[2].Left();
        }

        if (Input.GetKey(KeyCode.Keypad9))
        {
            ColdGasThrusterServices[0].Right();
            ColdGasThrusterServices[2].Right();
        }

        if (Input.GetKey(KeyCode.Keypad8))
        {
            ColdGasThrusterServices[0].Down();
            ColdGasThrusterServices[2].Up();
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            ColdGasThrusterServices[0].Up();
            ColdGasThrusterServices[2].Down();
        }
    }
}

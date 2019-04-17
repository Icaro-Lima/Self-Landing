using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotation : MonoBehaviour
{
    readonly float Speed = -90;

    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * Speed);
    }
}

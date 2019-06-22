using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeToXZ : MonoBehaviour
{
    Vector3 startingEulerAngles;
    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingEulerAngles = transform.eulerAngles;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(startingEulerAngles.x, transform.eulerAngles.y, startingEulerAngles.z);
        transform.position = new Vector3(transform.position.x, startingPosition.y, transform.position.z);
    }
}

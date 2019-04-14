using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonAim : MonoBehaviour
{
    public Transform TransformToAim;
    public bool Invert;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(TransformToAim);

        if (Invert)
        {
            transform.eulerAngles = -transform.eulerAngles;
        }
    }
}

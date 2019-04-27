using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetEngine : MonoBehaviour
{
    public float Force = 1;

    Light Light;

    // Start is called before the first frame update
    void Start()
    {
        Light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Force, 4 * Force, Force);
        Light.range = 5 * Force;
    }
}

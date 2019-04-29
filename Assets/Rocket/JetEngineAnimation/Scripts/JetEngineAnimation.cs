using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetEngineAnimation : MonoBehaviour
{
    [Range(0, 1)]
    public float ForceParameter = 0;

    Light Light;

    // Start is called before the first frame update
    void Start()
    {
        Light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float force = ForceParameter * 1.5f;

        transform.localScale = new Vector3(5 * force, 9 * force, 5 * force);
        Light.range = 5 * force;
    }
}

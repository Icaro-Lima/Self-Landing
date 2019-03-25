using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonsResize : MonoBehaviour
{
    public Transform Dest;

    private float Length;

    // Start is called before the first frame update
    void Start()
    {
        Length = (Dest.transform.position - transform.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        float length = (Dest.transform.position - transform.position).magnitude;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, length / Length);
    }
}

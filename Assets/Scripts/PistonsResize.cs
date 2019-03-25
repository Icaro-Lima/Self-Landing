using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonsResize : MonoBehaviour
{
    public Transform Target;
    public Transform Dest;

    private float Length;

    // Start is called before the first frame update
    void Start()
    {
        Length = (Dest.transform.position - Target.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        float length = (Dest.transform.position - Target.position).magnitude;
        Target.localScale = new Vector3(Target.localScale.x, Target.localScale.y, length / Length);
    }
}

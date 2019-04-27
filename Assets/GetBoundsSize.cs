using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GetBoundsSize : MonoBehaviour
{
    [ReadOnly]
    public Vector3 Size;

    // Start is called before the first frame update
    void Start()
    {
        Size = GetSize();
    }

    // Update is called once per frame
    void Update()
    {
        Size = GetSize();
    }

    Vector3 GetSize()
    {
        Bounds bounds = new Bounds();
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }

        return bounds.size;
    }
}

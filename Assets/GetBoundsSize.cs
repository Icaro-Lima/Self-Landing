using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GetBoundsSize : MonoBehaviour
{
    [ReadOnly]
    public Vector3 Size;
    public Vector3 Center;

    // Start is called before the first frame update
    void Start()
    {
        Bounds bounds = GetBounds();
        Size = bounds.size;
        Center = bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = GetBounds();
        Size = bounds.size;
        Center = bounds.center;
    }

    Bounds GetBounds()
    {
        Bounds bounds = new Bounds();
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }

        return bounds;
    }
}

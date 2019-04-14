using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealSize : MonoBehaviour
{
    public Vector3 RequestSize;

    public Vector3 TotalSize;
    public Vector3 MeshSize;

    public Vector3 SuggestedScales;

    // Start is called before the first frame update
    void Start()
    {
        TotalSize = GetComponent<MeshRenderer>().bounds.size;

        Vector3 scale = transform.localScale;

        MeshSize = new Vector3(TotalSize.x / scale.x, TotalSize.y / scale.y, TotalSize.z / scale.z);

        SuggestedScales = new Vector3(RequestSize.x / MeshSize.x, RequestSize.y / MeshSize.y, RequestSize.z / MeshSize.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

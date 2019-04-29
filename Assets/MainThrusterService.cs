using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThrusterService : MonoBehaviour
{
    [Range(0, 1)]
    public float TargetForceParameter = 0;

    Rigidbody RocketRigidbody;

    float ForceParameter = 0;
    readonly float ForceParameterUpVarByUpdate = 0.07f;
    readonly float ForceParameterDownVarByUpdate = 0.1f;

    public JetEngineAnimation JetEngineAnimation;

    // Start is called before the first frame update
    void Start()
    {
        RocketRigidbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleForces();

        JetEngineAnimation.ForceParameter = ForceParameter;
    }

    void HandleForces()
    {
        if (TargetForceParameter > ForceParameter)
        {
            ForceParameter += Mathf.Min(TargetForceParameter - ForceParameter, ForceParameterUpVarByUpdate);
        }
        else if (TargetForceParameter < ForceParameter)
        {
            ForceParameter -= Mathf.Min(ForceParameter - TargetForceParameter, ForceParameterDownVarByUpdate);
        }

        ForceParameter = Mathf.Clamp01(ForceParameter);

        RocketRigidbody.AddForceAtPosition(ForceParameter * transform.forward, transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThrusterService : MonoBehaviour
{
    public float TargetForceParameter = 0;

    public float ForceParameter;

    Rigidbody2D RocketRigidbody2D;

    AudioSource AudioSource;

    readonly float ForceMultiplier = 450f;
    readonly float ForceParameterUpVarByUpdate = 0.008f;
    readonly float ForceParameterDownVarByUpdate = 0.008f;

    public JetEngineAnimation JetEngineAnimation;

    // Start is called before the first frame update
    void Start()
    {
        RocketRigidbody2D = GetComponentInParent<Rigidbody2D>();

        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleForces();
        HandleSounds();

        JetEngineAnimation.ForceParameter = ForceParameter;
    }

    void HandleSounds()
    {
        AudioSource.volume = Mathf.SmoothStep(0, 0.5f, ForceParameter);
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

        RocketRigidbody2D.AddForceAtPosition(TargetForceParameter * ForceMultiplier * transform.forward * Time.fixedDeltaTime, transform.position);
    }
}

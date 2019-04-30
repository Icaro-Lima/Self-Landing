﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThrusterService : MonoBehaviour
{
    [Range(0, 1)]
    public float TargetForceParameter = 0;

    public float ForceParameter = 0;

    Rigidbody RocketRigidbody;

    AudioSource AudioSource;

    readonly float ForceMultiplier = 21f;
    readonly float ForceParameterUpVarByUpdate = 0.003f;
    readonly float ForceParameterDownVarByUpdate = 0.006f;

    public JetEngineAnimation JetEngineAnimation;

    // Start is called before the first frame update
    void Start()
    {
        RocketRigidbody = GetComponentInParent<Rigidbody>();

        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
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

        RocketRigidbody.AddForceAtPosition(ForceParameter * ForceMultiplier * transform.forward, transform.position);
    }
}

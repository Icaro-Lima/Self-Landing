using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdGasEmitter : MonoBehaviour
{
    public ParticleSystem PSThrusterUp;
    public ParticleSystem PSThrusterBackward;
    public ParticleSystem PSThrusterRight;
    public ParticleSystem PSThrusterLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Emit(ColdGasDirection direction)
    {
        switch (direction)
        {
            case ColdGasDirection.Up: PSThrusterUp.Play(); break;
            case ColdGasDirection.Backward: PSThrusterBackward.Play(); break;
            case ColdGasDirection.Right: PSThrusterRight.Play(); break;
            case ColdGasDirection.Left: PSThrusterLeft.Play(); break;
        }
    }
}

public enum ColdGasDirection
{
    Up, Backward, Left, Right
}
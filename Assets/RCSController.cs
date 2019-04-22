using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCSController : MonoBehaviour
{
    public Transform RCS;
    public Transform[] ColdGases;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Roll(RCSDirection direction)
    {
        ColdGasDirection coldGasDirection = ColdGasDirection.Up;
        if (direction == RCSDirection.Clockwise)
        {
            coldGasDirection = ColdGasDirection.Left;
        }
        else if (direction == RCSDirection.AntiClockwise)
        {
            coldGasDirection = ColdGasDirection.Right;
        }

        for (int i = 0; i < ColdGases.Length; i++)
        {
            ColdGases[i].GetComponent<ColdGasEmitter>().Emit(coldGasDirection);
        }
    }
}

public enum RCSDirection
{
    Clockwise, AntiClockwise
}

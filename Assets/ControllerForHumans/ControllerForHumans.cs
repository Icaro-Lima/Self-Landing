using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerForHumans : MonoBehaviour
{
    public RocketService RocketService;

    // Update is called once per frame
    void Update()
    {
        // Capta as teclas pressionadas.
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool q = Input.GetKey(KeyCode.Q);
        bool e = Input.GetKey(KeyCode.E);
        bool w = Input.GetKey(KeyCode.W);
        bool s = Input.GetKey(KeyCode.S);

        // Decide o poder do motor principal.
        if (up && down)
        {
            RocketService.SetTargetMainThrusterPower(RocketService.GetRealMainThrusterPower());
        }
        else if (!up && !down)
        {
            RocketService.SetTargetMainThrusterPower(RocketService.GetRealMainThrusterPower());
        }
        else if (up)
        {
            RocketService.SetTargetMainThrusterPower(1);
        }
        else
        {
            RocketService.SetTargetMainThrusterPower(0);
        }

        // Decide os movimentos do foguete.
        RocketService.Up(0, w);
        RocketService.Up(1, s);
        RocketService.Down(0, s);
        RocketService.Down(1, w);
        RocketService.Backward(0, s);
        RocketService.Backward(1, w);
        RocketService.Right(0, q);
        RocketService.Right(1, q);
        RocketService.Left(0, e);
        RocketService.Left(1, e);
    }
}

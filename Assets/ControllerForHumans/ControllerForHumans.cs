using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerForHumans : MonoBehaviour
{
    public RocketService RocketService;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);

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
    }
}

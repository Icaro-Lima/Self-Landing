using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsService : MonoBehaviour
{
    Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenLegs()
    {
        Animator.SetBool("Close", false);
    }
}

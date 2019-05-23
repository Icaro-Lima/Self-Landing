using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject[] GameObjectsToBeDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gameObject in GameObjectsToBeDestroyed)
        {
            Destroy(gameObject);
        }

        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

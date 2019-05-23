using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLandingAgent : Agent
{
    Rigidbody Rigidbody;

    RocketService RocketService;

    Vector3 InitialPosition;
    Quaternion InitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();

        RocketService = GetComponent<RocketService>();

        InitialPosition = Rigidbody.position;
        InitialRotation = Rigidbody.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Método chamado na hora que deve resetar por exemplo a posição do
    /// foguete. As configurações não necessariamente devem ser constantes,
    /// pode escolher uma posição aleatória a cada reset por exemplo.
    /// </summary>
    public override void AgentReset()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
        Rigidbody.position = InitialPosition;
        Rigidbody.rotation = InitialRotation;
    }

    /// <summary>
    /// Adiciona informações do estado atual em um vetor de observações.
    /// </summary>
    public override void CollectObservations()
    {
        AddVectorObs(Rigidbody.velocity);
        AddVectorObs(Rigidbody.angularVelocity);
        AddVectorObs(Rigidbody.position);
        AddVectorObs(Rigidbody.rotation);
        AddVectorObs(RocketService.NormalToThePlane());
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {

    }
}

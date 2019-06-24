using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLandingAgent : Agent
{
    public BoxCollider BoxCollider;

    Rigidbody Rigidbody;

    RocketService RocketService;
    GravityService GravityService;
    MainThrusterService MainThrusterService;

    Vector3 InitialPosition;
    Quaternion InitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();

        RocketService = GetComponent<RocketService>();
        GravityService = GetComponent<GravityService>();
        MainThrusterService = GetComponent<MainThrusterService>();

        InitialPosition = Rigidbody.position;
        InitialRotation = Rigidbody.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 normalFromThePlane = RocketService.NormalFromThePlane();
            Vector2 normalFromThePlane2 = new Vector2(normalFromThePlane.x, normalFromThePlane.z);

            normalFromThePlane2.x /= BoxCollider.bounds.max.x - BoxCollider.bounds.min.x;
            normalFromThePlane2.y /= BoxCollider.bounds.max.z - BoxCollider.bounds.min.z;

            print((normalFromThePlane2));
        }
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
        Vector2 position2 = new Vector2(Rigidbody.position.x, Rigidbody.position.z);
        float rotation2 = Rigidbody.rotation.y;

        Vector2 velocity2 = new Vector2(Rigidbody.velocity.x, Rigidbody.velocity.z);
        float angularVelocity2 = Rigidbody.angularVelocity.y;

        Vector3 normalFromThePlane = RocketService.NormalFromThePlane();
        Vector2 normalFromThePlane2 = new Vector2(normalFromThePlane.x, normalFromThePlane.z);

        float gravityN = GravityService.CompNormalizedGravity();
        float mainThrusterForceN = RocketService.GetRealMainThrusterPower();
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Main Thruster.
        RocketService.SetTargetMainThrusterPower(vectorAction[0]);

        // Right Rotation
        RocketService.Up(1, vectorAction[1] == 1);
        RocketService.Down(0, vectorAction[1] == 1);
        RocketService.Backward(0, vectorAction[1] == 1);

        // Left Rotation
        RocketService.Up(0, vectorAction[2] == 1);
        RocketService.Down(1, vectorAction[2] == 1);
        RocketService.Backward(1, vectorAction[2] == 1);
    }
}

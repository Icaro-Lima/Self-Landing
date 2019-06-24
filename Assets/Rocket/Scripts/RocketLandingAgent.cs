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
            print(Rigidbody.velocity);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Done();
    }

    /// <summary>
    /// Método chamado na hora que deve resetar por exemplo a posição do
    /// foguete. As configurações não necessariamente devem ser constantes,
    /// pode escolher uma posição aleatória a cada reset por exemplo.
    /// </summary>
    public override void AgentReset()
    {
        RocketService.ResetMainThrusterPower();

        RocketService.Up(1, false);
        RocketService.Down(0, false);
        RocketService.Backward(0, false);

        RocketService.Up(0, false);
        RocketService.Down(1, false);
        RocketService.Backward(1, false);

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
        float maxVelocityX = 30f;
        float maxVelocityZ = 120f;
        float maxAngularVelocity = 15f;

        float limitSizeX = BoxCollider.bounds.max.x - BoxCollider.bounds.min.x;
        float limitSizeZ = BoxCollider.bounds.max.z - BoxCollider.bounds.min.z;

        Vector3 normalFromThePlane = RocketService.NormalFromThePlane();
        Vector2 normalFromThePlane2 = new Vector2(normalFromThePlane.x, normalFromThePlane.z);
        float rotation = Rigidbody.rotation.y;

        Vector2 velocity2 = new Vector2(Rigidbody.velocity.x, Rigidbody.velocity.z);
        float angularVelocity = Rigidbody.angularVelocity.y;

        // Normalized Data:
        Vector2 normalFromThePlane2N = new Vector2(normalFromThePlane2.x / limitSizeX, normalFromThePlane2.y / limitSizeZ);
        float sin = Mathf.Sin(rotation * Mathf.Deg2Rad);
        float cos = Mathf.Cos(rotation * Mathf.Deg2Rad);

        Vector2 velocity2N = new Vector2(velocity2.x / maxVelocityX, velocity2.y / maxVelocityZ);
        float angularVelocityN = angularVelocity / maxAngularVelocity;

        float gravityN = GravityService.CompNormalizedGravity();
        float mainThrusterForceN = RocketService.GetRealMainThrusterPower();

        // Adds Observations:
        AddVectorObs(normalFromThePlane2N);
        AddVectorObs(sin);
        AddVectorObs(cos);
        AddVectorObs(velocity2N);
        AddVectorObs(angularVelocityN);
        AddVectorObs(gravityN);
        AddVectorObs(mainThrusterForceN);
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

        if (-Mathf.Sin(Rigidbody.rotation.y * Mathf.Deg2Rad) >= Mathf.Cos(7 * Mathf.Deg2Rad)) AddReward(0.3333f);
        if (Mathf.Abs(RocketService.NormalFromThePlane().x) <= 8) AddReward(0.3333f);
        if (Mathf.Abs(Rigidbody.velocity.z - (-25)) <= 5) AddReward(0.3333f);
    }
}

using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLandingAgent : Agent
{
    public BoxCollider2D BoxCollider;

    Rigidbody2D Rigidbody;

    RocketService RocketService;
    GravityService GravityService;
    MainThrusterService MainThrusterService;

    Vector2 InitialPosition;
    float InitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();

        RocketService = GetComponent<RocketService>();
        GravityService = GetComponent<GravityService>();
        MainThrusterService = GetComponent<MainThrusterService>();

        InitialPosition = Rigidbody.position + new Vector2(Random.Range(-30, 30), Random.Range(-30, 30));
        InitialRotation = Rigidbody.rotation + Random.Range(-25, 25);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            print(-Mathf.Sin(Rigidbody.rotation * Mathf.Deg2Rad));
        }
    }

    void OnTriggerExit2D(Collider2D other)
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
        Rigidbody.angularVelocity = 0;
        Rigidbody.position = InitialPosition;
        Rigidbody.rotation = InitialRotation;
    }

    /// <summary>
    /// Adiciona informações do estado atual em um vetor de observações.
    /// </summary>
    public override void CollectObservations()
    {
        float maxVelocityY = 120f;
        float maxAngularVelocity = 15f;

        float limitSizeY = BoxCollider.bounds.max.y - BoxCollider.bounds.min.y;

        Vector2 normalFromThePlane = RocketService.NormalFromThePlane();
        float rotation = Rigidbody.rotation;

        float angularVelocity = Rigidbody.angularVelocity;

        // Normalized Data:
        Vector2 normalFromThePlane2N = new Vector2(normalFromThePlane.x / limitSizeY, normalFromThePlane.y / limitSizeY);
        float sin = Mathf.Sin(rotation * Mathf.Deg2Rad);
        float cos = Mathf.Cos(rotation * Mathf.Deg2Rad);

        Vector2 velocity2N = Rigidbody.velocity / maxVelocityY;
        float angularVelocityN = angularVelocity / maxAngularVelocity;

        float gravityN = GravityService.CompNormalizedGravity();

        // Adds Observations:
        AddVectorObs(normalFromThePlane2N);
        AddVectorObs(sin);
        AddVectorObs(cos);
        AddVectorObs(velocity2N);
        AddVectorObs(angularVelocityN);
        //AddVectorObs(gravityN);
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

        if (Mathf.Cos(Rigidbody.rotation * Mathf.Deg2Rad) >= Mathf.Cos(15 * Mathf.Deg2Rad)) AddReward(0.3333f);
        if (Mathf.Abs(RocketService.NormalFromThePlane().x) <= 8) AddReward(0.3333f);
        if (Mathf.Abs(Rigidbody.velocity.y - (-25)) <= 5) AddReward(0.3333f);

        if (Mathf.Cos(Rigidbody.rotation * Mathf.Deg2Rad) <= Mathf.Cos(150 * Mathf.Deg2Rad)) AddReward(-1f);
    }
}

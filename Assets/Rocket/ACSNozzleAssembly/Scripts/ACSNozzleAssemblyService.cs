using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Essa classe representa as funções básicas de um ACS Nozzle Assembly.
/// Para se ter uma boa ideia, uma imagem do componente pode ser encontrada aqui:
/// https://drive.google.com/file/d/1Zw4vSG_TJJjkhdWT8bdmUphTVT_NcIHI/view?usp=sharing
/// 
/// Um ACS Nozzle Assembly pode ser usado para manobrar o foguete, jogando gás comprimido contra o
/// movimento desejado.
/// </summary>
public class ACSNozzleAssemblyService : MonoBehaviour
{
    public ParticleSystem ThrusterUp;
    public ParticleSystem ThrusterDown;
    public ParticleSystem ThrusterBackward;
    public ParticleSystem ThrusterRight;
    public ParticleSystem ThrusterLeft;

    float Influence = 50;

    /// <summary>
    /// Flag indicando se o bocal de cima está ligado.
    /// </summary>
    public bool UpEnabled;

    /// <summary>
    /// Flag indicando se o bocal de baixo está ligado.
    /// </summary>
    public bool DownEnabled;

    /// <summary>
    /// Flag indicando se o bocal de trás está ligado.
    /// </summary>
    public bool BackwardEnabled;

    /// <summary>
    /// Flag indicando se o bocal da direita está ligado.
    /// </summary>
    public bool RightEnabled;

    /// <summary>
    /// Flag indicando se o bocal da esquerda está ligado.
    /// </summary>
    public bool LeftEnabled;

    /// <summary>
    /// O RigidBody (controlador de física) do foguete. Note que essa classe deve estar atrelada a
    /// um GameObject dentro do foguete.
    /// </summary>
    Rigidbody RocketRigidBody;

    /// <summary>
    /// O Start é um evento do Unity que é chamado assim que o objeto é criado. Nesse caso ele está
    /// sendo usado para pegar o RigidBody do foguete.
    /// </summary>
    void Start()
    {
        RocketRigidBody = GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        if (UpEnabled)
        {
            Up();
        }

        if (DownEnabled)
        {
            Down();
        }

        if (BackwardEnabled)
        {
            Backward();
        }

        if (RightEnabled)
        {
            Right();
        }

        if (LeftEnabled)
        {
            Left();
        }
    }

    /// <summary>
    /// Libera gás comprimido do bocal de cima.
    /// </summary>
    void Up()
    {
        ThrusterUp.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterUp.transform.forward * Time.deltaTime * Influence, ThrusterUp.transform.position);
    }

    /// <summary>
    /// Libera gás comprimido do bocal de baixo.
    /// </summary>
    void Down()
    {
        ThrusterDown.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterDown.transform.forward * Time.deltaTime * Influence, ThrusterDown.transform.position);
    }

    /// <summary>
    /// Libera gás comprimido do bocal de trás.
    /// </summary>
    void Backward()
    {
        ThrusterBackward.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterBackward.transform.forward * Time.deltaTime * Influence, ThrusterBackward.transform.position);
    }

    /// <summary>
    /// Libera gás comprimido do bocal da direita.
    /// </summary>
    void Right()
    {
        ThrusterRight.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterRight.transform.forward * Time.deltaTime * Influence, ThrusterRight.transform.position);
    }

    /// <summary>
    /// Libera gás comprimido do bocal da esquerda.
    /// </summary>
    void Left()
    {
        ThrusterLeft.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterLeft.transform.forward * Time.deltaTime * Influence, ThrusterLeft.transform.position);
    }
}

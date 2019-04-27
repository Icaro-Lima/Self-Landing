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

    /// <summary>
    /// Libera gás comprimido do bocal da direita, gerando movimento para esquerda.
    /// </summary>
    public void Right()
    {
        ThrusterRight.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterRight.transform.forward, ThrusterRight.transform.position);
    }

    /// <summary>
    /// Libera gás comprimido do bocal da esquerda, gerando movimento para direita.
    /// </summary>
    public void Left()
    {
        ThrusterLeft.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterLeft.transform.forward, ThrusterLeft.transform.position);
    }

    /// <summary>
    /// Libera gás comprimido do bocal de cima, gerando movimento para baixo.
    /// </summary>
    public void Up()
    {
        ThrusterUp.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterUp.transform.forward, ThrusterUp.transform.position);
    }

    /// <summary>
    /// Libera gás comprimido do bocal de baixo, gerando movimento para cima.
    /// </summary>
    public void Down()
    {
        ThrusterDown.Play();
        RocketRigidBody.AddForceAtPosition(-ThrusterDown.transform.forward, ThrusterDown.transform.position);
    }
}

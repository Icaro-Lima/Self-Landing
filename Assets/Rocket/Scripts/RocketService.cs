using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Essa classe deve fornecer todos os sensores e atuadores do foguete. Ainda
/// faltam alguns sensores.
/// </summary>
public class RocketService : MonoBehaviour
{
    public GameObject Plane;

    Rigidbody2D Rigidbody;

    public Animator LegsAnimator;
    MainThrusterService MainThrusterService;
    ACSNozzleAssemblyService[] ACSNozzleAssemblyServices;

    // Start is called before the first frame update
    void Start()
    {
        if (Plane == null)
        {
            Debug.LogError("Plane null!");
        }

        Rigidbody = GetComponent<Rigidbody2D>();

        MainThrusterService = GetComponentInChildren<MainThrusterService>();
        ACSNozzleAssemblyServices = GetComponentsInChildren<ACSNozzleAssemblyService>();
    }

    public void OpenLegs()
    {
        LegsAnimator.SetBool("Close", false);
    }

    public void ResetLegs()
    {
        LegsAnimator.SetBool("Close", true);
    }

    public void ResetMainThrusterPower()
    {
        MainThrusterService.ForceParameter = 0;
    }

    /// <summary>
    /// Seta o poder do motor principal.
    /// </summary>
    /// <param name="power">O poder do motor, medido de 0 a 1.</param>
    public void SetTargetMainThrusterPower(float power)
    {
        MainThrusterService.TargetForceParameter = power;
    }

    /// <summary>
    /// Retorna o poder do motor principal.
    /// </summary>
    /// <returns>Retorna o poder do motor principal, um número de ponto
    /// flutuante de 0 a 1.</returns>
    public float GetRealMainThrusterPower()
    {
        return MainThrusterService.ForceParameter;
    }

    /// <summary>
    /// Retorna um vetor normal do foguete que aponta para o plano.
    /// </summary>
    public Vector2 NormalToThePlane()
    {
        return Plane.transform.position - Rigidbody.transform.position;
    }

    /// <summary>
    /// Retorna um vetor normal do plano que aponta para o foguete.
    /// </summary>
    public Vector2 NormalFromThePlane()
    {
        return Rigidbody.transform.position - Plane.transform.position;
    }

    /// <summary>
    /// Aciona um dos dois bocais superiores.
    /// </summary>
    /// <param name="assembly">O dispositivo a ser acionado. 0 ou 1.</param>
    /// <param name="enabled">Se o dispositivo deve ser ligado ou desligado.</param>
    public void Up(int assembly, bool enabled)
    {
        ACSNozzleAssemblyServices[assembly].UpEnabled = enabled;
    }

    /// <summary>
    /// Aciona um dos dois bocais inferiores.
    /// </summary>
    /// <param name="assembly">O dispositivo a ser acionado. 0 ou 1.</param>
    /// <param name="enabled">Se o dispositivo deve ser ligado ou desligado.</param>
    public void Down(int assembly, bool enabled)
    {
        ACSNozzleAssemblyServices[assembly].DownEnabled = enabled;
    }

    /// <summary>
    /// Aciona um dos dois bocais trazeiros. Note que se os dois forem
    /// acionados, a força resultante entre eles é zero.
    /// </summary>
    /// <param name="assembly">O dispositivo a ser acionado. 0 ou 1.</param>
    /// <param name="enabled">Se o dispositivo deve ser ligado ou desligado.</param>
    public void Backward(int assembly, bool enabled)
    {
        ACSNozzleAssemblyServices[assembly].BackwardEnabled = enabled;
    }

    /// <summary>
    /// Aciona um dos dois bocais da direita. Note que se ambos forem
    /// acionados, o foguete irá executar um movimento no sentido anti-horário.
    /// </summary>
    /// <param name="assembly">O dispositivo a ser acionado. 0 ou 1.</param>
    /// <param name="enabled">Se o dispositivo deve ser ligado ou desligado.</param>
    public void Right(int assembly, bool enabled)
    {
        ACSNozzleAssemblyServices[assembly].RightEnabled = enabled;
    }

    /// <summary>
    /// Aciona um dos dois bocais da esquerda. Note que se ambos forem
    /// acionados, o foguete irá executar um movimento no sentido horário.
    /// </summary>
    /// <param name="assembly">O dispositivo a ser acionado. 0 ou 1.</param>
    /// <param name="enabled">Se o dispositivo deve ser ligado ou desligado.</param>
    public void Left(int assembly, bool enabled)
    {
        ACSNozzleAssemblyServices[assembly].LeftEnabled = enabled;
    }
}

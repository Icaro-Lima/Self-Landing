using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketService : MonoBehaviour
{
    MainThrusterService MainThrusterService;

    // Start is called before the first frame update
    void Start()
    {
        MainThrusterService = GetComponentInChildren<MainThrusterService>();
    }

    // Update is called once per frame
    void Update()
    {

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
}

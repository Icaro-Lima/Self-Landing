using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// O intuito dessa classe é fornecer funções para manipular todo o conjunto ACS. Uma imagem pode
/// ser obtida aqui: https://www.nasa.gov/images/content/409261main_roll_control_animation_226.jpg.
/// </summary>
public class ACSService : MonoBehaviour
{
    /// <summary>
    /// Uma lista de todas as montagens de bocal (ACS Nozzle Assembly), no nosso caso são 4.
    /// </summary>
    public ACSNozzleAssemblyService[] ColdGasThrusterServices; // TODO: Renomear.

    /// <summary>
    /// O RigidBody (controlador de física) do foguete. Note que essa classe deve estar atrelada a
    /// um GameObject dentro do foguete.
    /// </summary>
    Rigidbody RocketRigidbody;

    /// <summary>
    /// O Start é um evento do Unity que é chamado assim que o objeto é criado. Nesse caso ele está
    /// sendo usado para pegar o RigidBody do foguete.
    /// </summary>
    void Start()
    {
        RocketRigidbody = GetComponentInParent<Rigidbody>();
    }

    // TODO: Esse método deve ser removido, está sendo usado temporariamente apenas para testes.
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad7))
        {
            ColdGasThrusterServices[0].Left();
            ColdGasThrusterServices[2].Left();
        }

        if (Input.GetKey(KeyCode.Keypad9))
        {
            ColdGasThrusterServices[0].Right();
            ColdGasThrusterServices[2].Right();
        }

        if (Input.GetKey(KeyCode.Keypad8))
        {
            ColdGasThrusterServices[0].Down();
            ColdGasThrusterServices[2].Up();
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            ColdGasThrusterServices[0].Up();
            ColdGasThrusterServices[2].Down();
        }
    }
}

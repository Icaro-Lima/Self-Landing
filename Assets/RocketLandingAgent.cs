using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLandingAgent : Agent
{
    Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
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

    }

    /// <summary>
    /// Adiciona informações do estado atual em um vetor de observações.
    /// </summary>
    public override void CollectObservations()
    {
        // Exemplo adicionando a posição atual ao vetor (o Unity sabe que a
        // posição tem 3 valores e cuida disso).
        AddVectorObs(Rigidbody.position);

        // Exemplo adicionando a rotação do foguete.
        // A rotação é um Quaternion. Uma breve estudada em ângulos de Euler
        // dá uma noção da necessidade do uso do Quaternion.
        AddVectorObs(Rigidbody.rotation);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Adicione recompensas.
        AddReward(0);
    }
}

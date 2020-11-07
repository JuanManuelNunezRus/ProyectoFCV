using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstadosEnemigo : MonoBehaviour
{
    public BattleStateMachine BSM;
    public EnemigoBase enemigo;
    
    public enum Turno {
        CARGANDO, 
        ELEGIR_ACCION,
        ESPERANDO,
        ACTUANDO,
        MUERTO
    }

    public Turno estadoTurno;
    // Barra de turno
    private float barraActual = 0f;
    private float barraMax = 7f;
    // GameObject
    private Vector3 posicionInicio;
    public GameObject objetoObjetivo;
    private float animSpeed = 5f;

    private bool accionEmpezada = false;

    void Start()
    {
        estadoTurno = Turno.CARGANDO;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        posicionInicio = transform.position;
    }

    void Update()
    {
        switch (estadoTurno)
        {
            case (Turno.CARGANDO):
                ActualizarBarraTurno();
                break;
            case (Turno.ELEGIR_ACCION):
                ElegirAccion();
                estadoTurno = Turno.ESPERANDO;
                break;
            case (Turno.ESPERANDO):

                break;
            case (Turno.ACTUANDO):
                StartCoroutine(TimeForAction());
                break;
            case (Turno.MUERTO):

                break;
        }
    }

    void ActualizarBarraTurno () 
    {
        barraActual = barraActual + Time.deltaTime;
        if (barraActual >= barraMax) 
        {
            estadoTurno = Turno.ELEGIR_ACCION;
        }
    }

    void ElegirAccion()
    {
        TurnHandler ataque = new TurnHandler();
        ataque.attacker = enemigo.nombre;
        ataque.tipo = "Enemigo";
        ataque.attackerObject = this.gameObject;
        ataque.target = BSM.aliados[Random.Range(0, BSM.aliados.Count)];
        BSM.RecibirAcciones(ataque);
    }

    private IEnumerator TimeForAction()
    {
        if (accionEmpezada)
        {
            yield break;
        }

        accionEmpezada = true;
        // Mover hacia el heroe
        Vector3 posicionObjetivo = new Vector3(
            objetoObjetivo.transform.position.x, 
            objetoObjetivo.transform.position.y, 
            objetoObjetivo.transform.position.z-1.5f
            );
        while (MoverseHaciaObjetivo(posicionObjetivo)) {yield return null;}
        // Esperar
        yield return new WaitForSeconds(1f);

        // Dañar

        // Devolver a posicion
        while (MoverseHaciaObjetivo(posicionInicio)) {yield return null;}
        // Borrar la accion de la lista de turnos
        BSM.listaTurnos.RemoveAt(0);
        // Reset BSM -> ESPERANDO
        BSM.battleState = BattleStateMachine.PerformAction.ESPERANDO;
        // Indicar que se ha acabado el ataque
        accionEmpezada = false;
        barraActual = 0f;
        estadoTurno = Turno.CARGANDO;
    }

    private bool MoverseHaciaObjetivo(Vector3 objetivo)
    {
        return objetivo != (transform.position = Vector3.MoveTowards(transform.position, objetivo, animSpeed * Time.deltaTime));
    }
}

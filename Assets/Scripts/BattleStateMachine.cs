using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine : MonoBehaviour
{
    public enum PerformAction
    {
        ESPERANDO,
        RECIBIR_ACCION,
        ACTUAR
    }
    public PerformAction battleState;

    public List<TurnHandler> listaTurnos = new List<TurnHandler>();
    public List<GameObject> aliados = new List<GameObject>();
    public List<GameObject> enemigos = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        battleState = PerformAction.ESPERANDO;
        aliados.AddRange(GameObject.FindGameObjectsWithTag("Aliado"));
        enemigos.AddRange(GameObject.FindGameObjectsWithTag("Enemigo"));
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case (PerformAction.ESPERANDO):
                if (listaTurnos.Count > 0)
                {
                    battleState = PerformAction.RECIBIR_ACCION;
                }
                break;
            case (PerformAction.RECIBIR_ACCION):
                GameObject performer = GameObject.Find(listaTurnos[0].attacker);
                if (listaTurnos[0].tipo == "Enemigo")
                {
                    MaquinaEstadosEnemigo ESM = performer.GetComponent<MaquinaEstadosEnemigo>();
                    ESM.objetoObjetivo = listaTurnos[0].target;
                    ESM.estadoTurno = MaquinaEstadosEnemigo.Turno.ACTUANDO;
                }
                else
                {
                    
                }
                battleState = PerformAction.ACTUAR;
                break;
            case (PerformAction.ACTUAR):
                
                break;
        }
    }

    public void RecibirAcciones(TurnHandler input)
    {
        listaTurnos.Add(input);
    }
}

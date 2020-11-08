using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaquinaEstadosProtagonista : MonoBehaviour
{
    public BattleStateMachine BSM;
    public ProtagonistaBase protagonista;

    public enum Turno {
        CARGANDO, 
        ADDTOLIST,
        ESPERANDO,
        ACTUANDO,
        MUERTO
    }

    public Turno estadoTurno;
    // Barra de turno
    private float barraActual = 0f;
    private float barraMax = 5f;
    public Image barraAtaque;
    public GameObject selector;

    void Start()
    {
        estadoTurno = Turno.CARGANDO;
        selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
    }

    void Update()
    {
        switch (estadoTurno)
        {
            case (Turno.CARGANDO):
                ActualizarBarraTurno();
                break;
            case (Turno.ADDTOLIST):
                BSM.aliadosPreparados.Add(this.gameObject);
                estadoTurno = Turno.ESPERANDO;
                break;
            case (Turno.ESPERANDO):

                break;
            case (Turno.ACTUANDO):

                break;
            case (Turno.MUERTO):

                break;
        }
    }

    void ActualizarBarraTurno () 
    {
        barraActual = barraActual + Time.deltaTime;
        float porcentaje = barraActual / barraMax;
        barraAtaque.transform.localScale = new Vector3(Mathf.Clamp(porcentaje, 0, 1), 1, 1);
        if (barraActual >= barraMax) 
        {
            estadoTurno = Turno.ADDTOLIST;
        }
    }
}

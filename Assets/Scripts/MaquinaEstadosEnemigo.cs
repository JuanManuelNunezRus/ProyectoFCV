using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstadosEnemigo : MonoBehaviour
{
    public EnemigoBase enemigo;
    
    public enum Turno {
        CARGANDO, 
        ADDTOLIST,
        ESPERANDO,
        ELIGIENDO,
        ACTUANDO,
        MUERTO
    }

    public Turno estadoTurno;
    // Barra de turno
    private float barraActual = 0f;
    private float barraMax = 7f;

    void Start()
    {
        estadoTurno = Turno.CARGANDO;
    }

    void Update()
    {
        switch (estadoTurno)
        {
            case (Turno.CARGANDO):
                ActualizarBarraTurno();
                break;
            case (Turno.ADDTOLIST):

                break;
            case (Turno.ESPERANDO):

                break;
            case (Turno.ELIGIENDO):

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
        if (barraActual >= barraMax) 
        {
            estadoTurno = Turno.ADDTOLIST;
        }
    }
}

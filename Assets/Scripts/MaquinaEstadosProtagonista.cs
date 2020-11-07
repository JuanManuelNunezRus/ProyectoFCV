using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaquinaEstadosProtagonista : MonoBehaviour
{
    public ProtagonistaBase protagonista;

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
    private float barraMax = 5f;
    public Image barraAtaque;

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
        float porcentaje = barraActual / barraMax;
        barraAtaque.transform.localScale = new Vector3(Mathf.Clamp(porcentaje, 0, 1), 1, 1);
        if (barraActual >= barraMax) 
        {
            estadoTurno = Turno.ADDTOLIST;
        }
    }
}

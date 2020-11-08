using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public enum HeroeGUI
    {
        ACTIVAR,
        ESPERAR,
        ACCION,
        ENEMIGO,
        DONE
    }

    public HeroeGUI inputHeroe;
    public List<GameObject> aliadosPreparados = new List<GameObject>();
    private TurnHandler eleccionHeroe;

    public GameObject botonEnemigo;
    public Transform spacer;

    public GameObject panelAtaque;
    public GameObject panelEnemigos;


    // Start is called before the first frame update
    void Start()
    {
        battleState = PerformAction.ESPERANDO;
        aliados.AddRange(GameObject.FindGameObjectsWithTag("Aliado"));
        enemigos.AddRange(GameObject.FindGameObjectsWithTag("Enemigo"));
        inputHeroe = HeroeGUI.ACTIVAR;

        panelAtaque.SetActive(false);
        panelEnemigos.SetActive(false);
        BotonesEnemigos();
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

        switch (inputHeroe)
        {
            case (HeroeGUI.ACTIVAR):
                if (aliadosPreparados.Count > 0)
                {
                    aliadosPreparados[0].transform.Find("Selector").gameObject.SetActive(true);
                    panelAtaque.SetActive(true);
                    inputHeroe = HeroeGUI.ESPERAR;
                }
                break;
            case (HeroeGUI.ESPERAR):
                break;
            case (HeroeGUI.DONE):
                break;
        }
    }

    public void RecibirAcciones(TurnHandler input)
    {
        listaTurnos.Add(input);
    }

    void BotonesEnemigos()
    {
        foreach (GameObject enemigo in enemigos)
        {
            GameObject nuevoBoton = Instantiate(botonEnemigo) as GameObject;
            BotonSeleccionEnemigo boton = nuevoBoton.GetComponent<BotonSeleccionEnemigo>();

            MaquinaEstadosEnemigo enemigoActual = enemigo.GetComponent<MaquinaEstadosEnemigo>();
            Text texto = nuevoBoton.GetComponentInChildren<Text>();
            texto.text = enemigoActual.enemigo.nombre;

            boton.enemigoPrefab = enemigo;

            nuevoBoton.transform.SetParent(spacer, false);
        }
    }
}

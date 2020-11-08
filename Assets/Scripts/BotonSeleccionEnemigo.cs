using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSeleccionEnemigo : MonoBehaviour
{
    public GameObject enemigoPrefab;

    public void ElegirEnemigo()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        
    }
}

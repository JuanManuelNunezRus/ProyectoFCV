using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine: MonoBehaviour
{
    public enum PerformAction
    {
        ESPERANDO,
        RECIBIR_ACCION,
        ACTUAR
    }
    public PerformAction battleState;

    // Start is called before the first frame update
    void Start()
    {
        battleState = PerformAction.ESPERANDO;
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case (PerformAction.ESPERANDO)
                
                break;
            case (PerformAction.RECIBIR_ACCION)
                
                break;
            case (PerformAction.ACTUAR)
                
                break;
        }
    }
}

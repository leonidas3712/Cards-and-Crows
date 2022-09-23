using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Invoking events!");
        EventManager.Instance.gameStartedEvent.Invoke();
        EventManager.Instance.playerTurnStartedEvent.Invoke();
        EventManager.Instance.playerTurnEndedEvent.Invoke();
        EventManager.Instance.enemyTurnStartedEvent.Invoke();
        EventManager.Instance.enemyTurnEndedEvent.Invoke();
        EventManager.Instance.gameEndedEvent.Invoke();
    }

    
}

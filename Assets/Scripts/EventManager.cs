using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    private static EventManager _instance;
    public static EventManager Instance
    {
        get {
            if (_instance == null)
                _instance = new EventManager();

            return _instance;
        }
    }

    public UnityEvent gameStartedEvent = new UnityEvent();
    public UnityEvent gameEndedEvent = new UnityEvent();
    public UnityEvent turnStartedEvent = new UnityEvent();
    public UnityEvent playerTurnStartedEvent = new UnityEvent();
    public UnityEvent enemyTurnStartedEvent = new UnityEvent();
    public UnityEvent turnEndedEvent = new UnityEvent();
    public UnityEvent playerTurnEndedEvent = new UnityEvent();
    public UnityEvent enemyTurnEndedEvent = new UnityEvent();

    private EventManager() {
        Debug.Log("Setting events...");
        playerTurnStartedEvent.AddListener(turnStartedEvent.Invoke);
        enemyTurnStartedEvent.AddListener(turnStartedEvent.Invoke);
        playerTurnEndedEvent.AddListener(turnEndedEvent.Invoke);
        enemyTurnEndedEvent.AddListener(turnEndedEvent.Invoke);
    }

}
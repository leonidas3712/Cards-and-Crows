using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerComponent : MonoBehaviour
{
    public static UnityEvent gameStartedEvent = new UnityEvent();
    public static UnityEvent gameEndedEvent = new UnityEvent();
    public static UnityEvent turnStartedEvent = new UnityEvent();
    public static UnityEvent playerTurnStartedEvent = new UnityEvent();
    public static UnityEvent enemyTurnStartedEvent = new UnityEvent();
    public static UnityEvent turnEndedEvent = new UnityEvent();
    public static UnityEvent playerTurnEndedEvent = new UnityEvent();
    public static UnityEvent enemyTurnEndedEvent = new UnityEvent();


    private void InitializeInnerEvents() {
        Debug.Log("Initializing inner events...");
        playerTurnStartedEvent.AddListener(turnStartedEvent.Invoke);
        enemyTurnStartedEvent.AddListener(turnStartedEvent.Invoke);
        playerTurnEndedEvent.AddListener(turnEndedEvent.Invoke);
        enemyTurnEndedEvent.AddListener(turnEndedEvent.Invoke);
    }

    void Awake() {
        InitializeInnerEvents();
    }

    public static bool IsGameEnd() { 
        return (
            !HeroComponent.playerHeroInstance.IsAlive()
            || !HeroComponent.enemyHeroInstance.IsAlive()
        );
    }

    // Start is called before the first frame update    
    void Start()
    {
        Debug.Log("Invoking events!");
        gameStartedEvent.Invoke();
    }
}

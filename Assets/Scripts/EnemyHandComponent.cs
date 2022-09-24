using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandComponent : HandComponent
{
    protected override void Awake() {
        base.Awake();
        GameManagerComponent.enemyTurnStartedEvent.AddListener(PlayTurn);
        GameManagerComponent.gameStartedEvent.AddListener(GameManagerComponent.enemyTurnStartedEvent.Invoke);
        GameManagerComponent.battleEndedEvent.AddListener(GameManagerComponent.enemyTurnStartedEvent.Invoke);
        GameManagerComponent.enemyTurnStartedEvent.AddListener(() => { isPlaying = true; });
        GameManagerComponent.enemyTurnEndedEvent.AddListener(() => { isPlaying = false; });
    }

    public override void PlayTurn() {
        base.PlayTurn();
        Debug.Log("Enemy Turn Start" + gameObject);
        Invoke(nameof(EndTurn), 3);
    }

    void EndTurn() {
        Debug.Log("Enemy turn end");
        GameManagerComponent.enemyTurnEndedEvent.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandComponent : HandComponent
{
    public const int ENEMY_DEFAULT_MANA = 5;
    protected override void Awake() {
        base.Awake();
        GameManagerComponent.enemyTurnStartedEvent.AddListener(PlayTurn);
        GameManagerComponent.gameStartedEvent.AddListener(GameManagerComponent.enemyTurnStartedEvent.Invoke);
        GameManagerComponent.battleEndedEvent.AddListener(GameManagerComponent.enemyTurnStartedEvent.Invoke);
        GameManagerComponent.enemyTurnStartedEvent.AddListener(() => { isPlaying = true; });
        GameManagerComponent.enemyTurnEndedEvent.AddListener(() => { isPlaying = false; });
    }

    public override void PlayTurn() {
        this.start_turn_mana = ENEMY_DEFAULT_MANA;
        base.PlayTurn();
        Debug.Log("Enemy Turn Start" + gameObject);
    }
}

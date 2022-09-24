using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandComponent : HandComponent
{
    protected override void Awake() {
        base.Awake();
        GameManagerComponent.playerTurnStartedEvent.AddListener(PlayTurn);
        GameManagerComponent.enemyTurnEndedEvent.AddListener(GameManagerComponent.playerTurnStartedEvent.Invoke);
    }

    public override void PlayTurn() {
        base.PlayTurn();
        Debug.Log("Player Turn started");
    }
}

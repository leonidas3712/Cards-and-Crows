using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandComponent : HandComponent
{
    protected override void Awake() {
        base.Awake();
        GameManagerComponent.enemyTurnStartedEvent.AddListener(PlayTurn);
    }

    public override void PlayTurn() {
        base.PlayTurn();
    }
}

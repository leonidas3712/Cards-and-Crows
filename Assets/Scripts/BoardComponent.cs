using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardComponent : MonoBehaviour
{
    void Awake() {
        GameManagerComponent.battleStartedEvent.AddListener(Battle);
        GameManagerComponent.playerTurnEndedEvent.AddListener(GameManagerComponent.battleStartedEvent.Invoke);
    }

    void Battle() {
        Debug.Log("Battle Started");
        foreach (LaneComponent lane in GetComponentsInChildren<LaneComponent>()) {
            // lane.Attack();
        }
        Debug.Log("Battle Ended");
        GameManagerComponent.battleEndedEvent.Invoke();
    }
}

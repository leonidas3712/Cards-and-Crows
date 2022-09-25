using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardComponent : MonoBehaviour
{
    void Awake() {
        GameManagerComponent.battleStartedEvent.AddListener(
            () => {
                StartCoroutine(Battle());
            }
        );
        GameManagerComponent.playerTurnEndedEvent.AddListener(GameManagerComponent.battleStartedEvent.Invoke);
    }

    IEnumerator Battle() {
        Debug.Log("Battle Started");
        foreach (LaneComponent lane in GetComponentsInChildren<LaneComponent>()) {
            if (lane.Attack()) {
                yield return new WaitForSeconds(1f);
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("Battle Ended");
        if (GameManagerComponent.IsGameEnd()) {
            GameManagerComponent.gameEndedEvent.Invoke();
        }
        else {   
            GameManagerComponent.battleEndedEvent.Invoke();
        }
    }
}

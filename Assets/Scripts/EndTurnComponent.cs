using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnComponent : MonoBehaviour
{
    [SerializeField]
    private Button endturn_btn;

    public void Start() {
        GameManagerComponent.playerTurnStartedEvent.AddListener(
            () => {
                endturn_btn.interactable = true;
            }
        );
    }

    public void EndTurn() {
        Debug.Log("Turn End!");
        endturn_btn.interactable = false;
        GameManagerComponent.playerTurnEndedEvent.Invoke();
    }
}

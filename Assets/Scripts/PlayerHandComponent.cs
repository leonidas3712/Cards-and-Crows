using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandComponent : HandComponent
{
    private PlayerCardComponent selectedCard;

    protected override void Awake() {
        base.Awake();
        GameManagerComponent.playerTurnStartedEvent.AddListener(PlayTurn);
        GameManagerComponent.enemyTurnEndedEvent.AddListener(GameManagerComponent.playerTurnStartedEvent.Invoke);
        GameManagerComponent.playerTurnEndedEvent.AddListener(DeselectCurrentCard);
        GameManagerComponent.playerTurnStartedEvent.AddListener(() => { isPlaying = true; });
        GameManagerComponent.playerTurnEndedEvent.AddListener(() => { isPlaying = false; });
    }

    public override void PlayTurn() {
        base.PlayTurn();
        Debug.Log("Player Turn started");
    }

    public void SelectCard(PlayerCardComponent cardComponent) {
        if (isPlaying) {
            if (cardComponent == selectedCard) {
                return;
            }
            if (selectedCard != null) {
                selectedCard.OnDeselectCard();
            }
            selectedCard = cardComponent;
            selectedCard.OnSelectCard();
        }
    }

    public void DeselectCurrentCard() {
        if (null != selectedCard) {
            selectedCard.OnDeselectCard();
            selectedCard = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandComponent : HandComponent
{
    [HideInInspector]
    public PlayerCardComponent selectedCard;

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

    public override void NotEnoughMana() {
        GameManagerComponent.Instance.QueueMessage("Not enough mana", 0.1f);
    }

    public void SelectCard(PlayerCardComponent cardComponent) {
        if (selectedCard != null) {
            selectedCard.OnDeselectCard();
        }
        if (cardComponent == selectedCard) {
            return;
        }
        if (PlayerInputManager.Instance.is_in_switch_mode) {
            GameManagerComponent.Instance.QueueMessage("Can't select card when\nSwitch Position is ON", 0.5f);
            return;
        }
        if (isPlaying) {
            if (Mana >= cardComponent.card_so.cost) {
                selectedCard = cardComponent;
                selectedCard.OnSelectCard();
            } else {
                NotEnoughMana();
            }
        }
    }

    public void DeselectCurrentCard() {
        if (null != selectedCard) {
            selectedCard.OnDeselectCard();
            selectedCard = null;
        }
    }
}

/**
 * This file is responsable for user inputs like pressing on Slots for placing minions or for switching their places.
 * Note that Card selection and End Turn are not managed here.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    // Singleton instance
    private static PlayerInputManager _instance;
    public static PlayerInputManager Instance {
        get {
            if (_instance == null) {
                throw new SystemException("PlayerInputManager has not yet initiated!");
            }
            return _instance;
        }
    }

    // Input manager
    public bool is_in_switch_mode = false;
    public SlotComponent first_switch_slot = null;

    public PlayerHandComponent playerHand;
    private bool isPlayerTurn;

    void Awake() {
        _instance = this;
        GameManagerComponent.playerTurnStartedEvent.AddListener(
            () => {
                isPlayerTurn = true;
            }
        );
        GameManagerComponent.playerTurnEndedEvent.AddListener(
            () => {
                isPlayerTurn = false;
            }
        );
    }

    public void HandleSlotClick(SlotComponent slot) {
        if (playerHand.selectedCard != null) {
            playerHand.selectedCard.PlayCard(slot);
            return;
        }

        if (is_in_switch_mode)
        {
            if (first_switch_slot != null && slot != first_switch_slot)
            {
                slot.switchMinion(first_switch_slot);
                first_switch_slot = null;
            }
            else if(slot.current_minion != null)
            {
                first_switch_slot = slot;
            }
        }
    }

    public bool CanSlotBeSelected() {
        return isPlayerTurn;
    }
}

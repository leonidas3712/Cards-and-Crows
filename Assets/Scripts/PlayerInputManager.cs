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
    public BoardComponent board;
    private LinkedList<SpriteRenderer> slotBorderSprites = new LinkedList<SpriteRenderer>();
    public Color slotSpriteDefaultBorderColor;
    public Color slotSpriteSwitchBorderColor;

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

    void Start() {
        foreach (LaneComponent lane in board.GetComponentsInChildren<LaneComponent>()) {
            SpriteRenderer sprite = lane.playerSlot.border.GetComponent<SpriteRenderer>();
            slotBorderSprites.AddFirst(sprite);
            sprite.color = slotSpriteDefaultBorderColor;
        }
    }

    public void SetSwitchMode(bool state) {
        Debug.Log("Seting switch mode to " + state);
        is_in_switch_mode = state;
        if (state) {
            playerHand.DeselectCurrentCard();
            foreach(SpriteRenderer slotSprite in slotBorderSprites) {
                slotSprite.color = slotSpriteSwitchBorderColor;
            }
        } else {
            if (first_switch_slot != null) {
                first_switch_slot.DeselectSlot();
            }
            foreach(SpriteRenderer slotSprite in slotBorderSprites) {
                slotSprite.color = slotSpriteDefaultBorderColor;
            }
        }
    }

    public void HandleSlotClick(SlotComponent slot) {
        if (playerHand.selectedCard != null) {
            playerHand.selectedCard.PlayCard(slot);
            return;
        }

        if (is_in_switch_mode)
        {
            if (first_switch_slot != null)
            {
                first_switch_slot.DeselectSlot();
                slot.DeselectSlot(); // To temporarily remove border
                if (slot.current_minion == first_switch_slot.current_minion) {
                    // (Occurs when same slot is selected, or if both slots are empty)
                    first_switch_slot = null;
                    return;
                }
                if (playerHand.Mana < 1) {
                    playerHand.NotEnoughMana();
                    first_switch_slot = null;
                    return;
                }
                slot.switchMinion(first_switch_slot);
                first_switch_slot = null;
                playerHand.Mana -= 1;
            }
            else
            {
                first_switch_slot = slot;
                first_switch_slot.SelectSlot();
            }
        }
    }

    public bool CanSlotBeSelected() {
        return isPlayerTurn;
    }
}

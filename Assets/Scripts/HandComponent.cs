using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HandComponent : MonoBehaviour
{
    public const int DEFAULT_MANA_AMOUNT = 5;
    public const int INITIAL_CARD_COUNT = 5;
    public DeckComponent deck;
    public int current_mana;
    private List<CardComponent> cards = new List<CardComponent>();
    public TextMeshProUGUI current_mana_text;

    void Awake()
    {
        GameManagerComponent.playerTurnStartedEvent.AddListener(DrawCard);
        GameManagerComponent.playerTurnStartedEvent.AddListener(() => {
            SetMana(DEFAULT_MANA_AMOUNT);
        });
    }

    void SetMana(int mana)
    {
        Debug.Log("Setting Mana to " + mana);
        current_mana = mana;
        current_mana_text.text = current_mana.ToString();
    }

    void DrawInitialCards() {
        for (int i = 0; i < INITIAL_CARD_COUNT; i++) {
            DrawCard();
        }
    }

    void DrawCard() {
        Debug.Log("Player drawing card");
        CardComponent card = deck.DrawCard(this);
        if (card == null) {
            Debug.Log("No cards left in deck.");
            return;
        }

        cards.Add(card);
        foreach(Transform child in transform) {
            Debug.Log(child);
            CardComponent cardComponent = child.GetComponent<CardComponent>(); 
            cardComponent.AdjustCardPosition();
        }
    }
}

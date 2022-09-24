using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HandComponent : MonoBehaviour
{
    public const int DEFAULT_MANA_AMOUNT = 5;
    public const int INITIAL_CARD_COUNT = 5;
    public DeckComponent deck;
    private int current_mana;
    protected List<CardComponent> cards = new List<CardComponent>();
    public TextMeshProUGUI current_mana_text;
    private bool isFirstTurn = true;

    public CardComponent cardPrefab;


    public int Mana {
        get { 
            return current_mana;
        }
        set {
            Debug.Log("Setting Mana to " + value);
            current_mana = value;
            current_mana_text.text = current_mana.ToString();
        }
    }

    public virtual void PlayTurn() {
        Mana = DEFAULT_MANA_AMOUNT;
        if (isFirstTurn) {
            isFirstTurn = false;
        }
        else {
            DrawCard();
        }
    }

    void DrawInitialCards() {
        Debug.Log("Drawing initial cards");
        for (int i = 0; i < INITIAL_CARD_COUNT; i++) {
            DrawCard();
        }
    }

    void DrawCard() {
        Card_ScriptableObject card_so = deck.DrawCard();

        if (card_so == null) {
            Debug.Log("No cards left in deck.");
            return;
        }

        CardComponent card = Instantiate(cardPrefab, transform);
        card.SetScriptableObject(card_so);

        cards.Add(card);
        foreach(Transform child in transform) {
            Debug.Log(child);
            CardComponent cardComponent = child.GetComponent<CardComponent>(); 
            cardComponent.AdjustCardPosition();
        }
    }

    protected virtual void Start() {
        GameManagerComponent.gameStartedEvent.AddListener(DrawInitialCards);
    }
}

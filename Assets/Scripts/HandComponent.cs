using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HandComponent : MonoBehaviour
{
    public const int DEFAULT_MANA_AMOUNT = 5;
    public const int INITIAL_CARD_COUNT = 5;
    public DeckComponent deck;
    public HeroComponent hero;
    private int current_mana;
    [HideInInspector]
    public List<CardComponent> cards = new List<CardComponent>();
    public TextMeshProUGUI current_mana_text;
    private bool isFirstTurn = true;
    protected bool isPlaying = false;

    public CardComponent cardPrefab;

    public int Mana {
        get { 
            return current_mana;
        }
        set {
            current_mana = value;
            current_mana_text.text = current_mana.ToString();
        }
    }

    public virtual void NotEnoughMana() {
        // Overriden by PlayerHandComponent.
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
        for (int i = 0; i < INITIAL_CARD_COUNT; i++) {
            DrawCard();
        }
    }

    public void AdjustCards() {
        int card_index = 0;
        foreach(Transform child in transform) {
            CardComponent cardComponent = child.GetComponent<CardComponent>(); 
            cardComponent.AdjustCardPosition(card_index, transform.childCount);
            card_index++;
        }
    }

    void DrawCard() {
        Card_ScriptableObject card_so = deck.DrawCard();

        if (card_so == null) {
            GameManagerComponent.Instance.QueueMessage("Dealing damage - no cards in deck!", 1f);
            hero.Hit(1);
            return;
        }
        
        CardComponent card = Instantiate(cardPrefab, transform);
        card.InitiateCard(this, card_so);

        cards.Add(card);

        AdjustCards();
        card.BringCardFromDeck(transform.childCount);
    }

    protected virtual void Awake() {
        GameManagerComponent.gameStartedEvent.AddListener(DrawInitialCards);
    }
}

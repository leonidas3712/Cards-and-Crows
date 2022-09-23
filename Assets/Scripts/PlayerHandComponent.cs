using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandComponent : MonoBehaviour
{
    public DeckComponent deck;

    private LinkedList<CardComponent> cards = new LinkedList<CardComponent>();

    void Awake()
    {
        EventManager.Instance.playerTurnStartedEvent.AddListener(DrawCard);
    }

    void DrawCard() {
        Debug.Log("Player drawing card");
        CardComponent card = deck.DrawCard(this);
        if (card == null) {
            Debug.Log("No cards left in deck.");
            return;
        }
        foreach(CardComponent child in transform)
        {
            child.AdjustCardPosition();
        }
    }
}

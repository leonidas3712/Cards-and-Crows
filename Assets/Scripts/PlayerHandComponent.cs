using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandComponent : MonoBehaviour
{
    public DeckComponent deck;

    void Awake()
    {
        EventManager.Instance.playerTurnStartedEvent.AddListener(DrawCard);
    }

    void DrawCard() {
        Debug.Log("Player drawing card");
    }
}

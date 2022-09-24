using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardComponent : MonoBehaviour
{
    protected HandComponent hand;
    public Card_ScriptableObject card_so;

    private readonly float distanceBetweenCards = 1.9f;

    public virtual void InitiateCard(HandComponent hand, Card_ScriptableObject card_so)
    {
        this.hand = hand;
        this.card_so = card_so;
    }

    public virtual void PlayCardToMinion(SlotComponent slot)
    {
        if(!slot.CreateMinion(card_so)) Destroy(gameObject);
    }
    
    public void AdjustCardPosition(int cardIndex, int amountOfCards)
    {
        transform.DOMoveX(distanceBetweenCards * (cardIndex - (amountOfCards-1)/2f), 1);
    }
}

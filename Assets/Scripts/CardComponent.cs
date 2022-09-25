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

    public virtual void PlayCard(SlotComponent slot)
    {
        if (hand.Mana - card_so.cost >= 0)
        {
            if (slot.CreateMinion(card_so))
            {
                transform.SetParent(null);
                Destroy(gameObject);
                hand.AdjustCards();
            }
            hand.Mana -= card_so.cost;
        }

    }

    public void AdjustCardPosition(int cardIndex, int amountOfCards)
    {
        transform.DOLocalMove(new Vector3(distanceBetweenCards * (cardIndex - (amountOfCards - 1) / 2f), 0, 0), 1);
    }

    public void BringCardFromDeck(int amountOfCards)
    {
        transform.DOMove(new Vector3(distanceBetweenCards * (amountOfCards - 1) / 2f, transform.position.y, transform.position.z), 1).From(hand.deck.transform.position);
    }
}

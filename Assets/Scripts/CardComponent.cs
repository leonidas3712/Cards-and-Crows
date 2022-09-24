using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CardComponent : MonoBehaviour
{
    protected HandComponent hand;
    public Card_ScriptableObject card_so;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI attributeText;
    public Image cardImage;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI attackStrength;

    private readonly float distanceBetweenCards = 1.7f;

    public void InitiateCard(HandComponent hand, Card_ScriptableObject card_so)
    {
        this.hand = hand;
        this.card_so = card_so;
        nameText.text = card_so.cardName;
        //attributeText.text = card_so.attributes.ToString();
        cardImage.sprite = card_so.image;
        HP.text = card_so.hp.ToString();
        cost.text = card_so.cost.ToString();
        attackStrength.text = card_so.attackStrength.ToString();
    }

    public virtual void PlayCardToMinion(SlotComponent slot)
    {
        slot.CreateMinion(card_so);
        Destroy(gameObject);
    }
    
    public void AdjustCardPosition(int cardIndex, int amountOfCards)
    {
        transform.DOMoveX(distanceBetweenCards * (cardIndex - (amountOfCards-1)/2f), 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PlayerCardComponent : CardComponent
{
    private bool isCardHovered = false;
    private bool isCardSelected = false;
    private Vector3 originalScale;
    private Vector3 upScale;
    public Image border;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI attributeText;
    public Image cardImage;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI cost;
    public TextMeshProUGUI attackStrength;

    public Color deselectedColor;
    public Color selectedColor;
    
    public void Start() {
        originalScale = transform.localScale;
        upScale = originalScale * 1.2f;
        Debug.Log(border);
        border.color = deselectedColor;
    }

    public override void InitiateCard(HandComponent hand, Card_ScriptableObject card_so)
    {
        base.InitiateCard(hand, card_so);

        nameText.text = card_so.cardName;
        //attributeText.text = card_so.attributes.ToString();
        cardImage.sprite = card_so.image;
        HP.text = card_so.hp.ToString();
        cost.text = card_so.cost.ToString();
        attackStrength.text = card_so.attackStrength.ToString();
    }

    public override void PlayCardToMinion(SlotComponent slot)
    {
        base.PlayCardToMinion(slot);
    }

    void OnMouseEnter()
    {
        if (isCardHovered) {
            return;
        }
        isCardHovered = true;
        transform.DOScale(upScale, 0.3f);
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            ((PlayerHandComponent)hand).SelectCard(this);
        }
    }

    void OnMouseExit()
    {
        if (!isCardHovered) {
            return;
        }
        isCardHovered = false;
        if (!isCardSelected) {
            transform.DOScale(originalScale, 0.3f);
        }
    }
    
    public virtual void OnSelectCard()
    {
        isCardSelected = true;
        border.color = selectedColor;
    }

    public virtual void OnDeselectCard()
    {
        isCardSelected = false;
        if (!isCardHovered) {
            transform.DOScale(originalScale, 0.3f);
        }
        border.color = deselectedColor;
    }
}

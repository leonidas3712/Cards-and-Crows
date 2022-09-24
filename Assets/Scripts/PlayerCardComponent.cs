using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCardComponent : CardComponent
{
    private bool isCardHovered = false;
    private bool isCardSelected = false;
    private Vector3 originalScale;
    private Vector3 upScale;

    public void Start() {
        originalScale = transform.localScale;
        upScale = originalScale * 1.2f;
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
    }

    public virtual void OnDeselectCard()
    {
        isCardSelected = false;
        if (!isCardHovered) {
            transform.DOScale(originalScale, 0.3f);
        }
    }
}

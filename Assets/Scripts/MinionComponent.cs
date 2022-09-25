using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class MinionComponent : EntityComponent
{
    [HideInInspector]
    public Card_ScriptableObject cardSO;
    [HideInInspector]
    public SlotComponent slot;

    List<Attribute> attributeList;
    // public TextMeshProUGUI nameText;
    // public TextMeshProUGUI attributeText;
    public SpriteRenderer minionSprite;
    public TextMeshProUGUI attackStrength;

    public void InitiateMinion(SlotComponent slot, Card_ScriptableObject card_so){
        SetSlot(slot);
        this.cardSO = card_so;
        SetAttributes();
        HP = card_so.hp;
        // nameText.text = card_so.cardName;
        //attributeText.text = card_so.attributes.ToString();
        minionSprite.sprite = card_so.image;
        attackStrength.text = card_so.attackStrength.ToString();
    }

    public void SetSlot(SlotComponent slot) {
        this.slot = slot;
    }

    public void SetAttributes()
    {
        attributeList = new List<Attribute>();
        foreach(GameObject attributeObject in cardSO.attributes){
           attributeList.Add(Instantiate(attributeObject,transform).GetComponent<Attribute>());
        }
        foreach(Attribute attribute in attributeList){
            attribute.RegisterAttribute();
        }
    }

    private HeroComponent getOpposingHero() {
        if (slot.isPlayerSided) {
            return HeroComponent.enemyHeroInstance;
        }
        return HeroComponent.playerHeroInstance;
    }

    public Sequence Attack() {
        EntityComponent target = slot.opposingSlot.current_minion;
        Vector3 targetPosition;
        if (target == null) {
            target = getOpposingHero();
            targetPosition = target.transform.position;
        } else {
            targetPosition = (target.transform.position + transform.position) / 2;
        }
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(targetPosition, 0.4f));
        sequence.AppendCallback(
            () => {
                target.Hit(cardSO.attackStrength);
            }
        );
        sequence.Append(transform.DOLocalMove(Vector3.zero, 0.4f));
        return sequence;
    }

    public override void Death() {
        Destroy(gameObject);
    }
}

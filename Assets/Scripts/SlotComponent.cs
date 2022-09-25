using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SlotComponent : MonoBehaviour
{
    [HideInInspector]
    public LaneComponent lane;
    [HideInInspector]
    public MinionComponent current_minion;
    public bool isPlayerSided; // true = Player's slot        false = Enemy's slot .   DO NOT MODIFY. READONLY.
    public SlotComponent opposingSlot;
    public MinionComponent minionPrefab;
    public SpriteRenderer border;
    public Color defaultBorderColor;
    public Color hoveredBorderColor;

    bool isSlotHoverd;
    private Vector3 originalScale;
    private Vector3 upScale;

    public static SlotComponent selectedSlot;

    public void Start() {
        originalScale = transform.localScale;
        upScale = originalScale * 1.2f;
    }

    public void DetachMinion(){
        if (this.current_minion != null)
        {
            current_minion.transform.SetParent(null);
            current_minion = null;
        }
    }

    public void AttachMinion(MinionComponent minion)
    {
        if (minion == null)
        {
            current_minion = null;
            return;
        }

        if (current_minion != null)
        {
            return;
        }
        current_minion = minion;
        current_minion.transform.SetParent(transform);
        current_minion.transform.localPosition = Vector3.zero;
        current_minion.SetSlot(this);
    }

    public void switchMinion(SlotComponent other_slot) {
        MinionComponent other_minion = other_slot.current_minion;
        MinionComponent curr_minion = this.current_minion;

        this.DetachMinion();
        other_slot.DetachMinion();
        other_slot.AttachMinion(curr_minion);
        this.AttachMinion(other_minion);
    }

    public bool CreateMinion(Card_ScriptableObject card_so){
        if (current_minion != null) {
            return false;
        }
        MinionComponent minion = Instantiate(minionPrefab);
        minion.InitiateMinion(this, card_so);
        AttachMinion(minion);
        return true;
    } 

    void OnMouseEnter()
    {
        if (isSlotHoverd) {
            return;
        }
        if (!PlayerInputManager.Instance.CanSlotBeSelected()) {
            return;
        }
        isSlotHoverd = true;
        border.DOFade(1, 0.1f);
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            PlayerInputManager.Instance.HandleSlotClick(this);
        }
    }

    void OnMouseExit()
    {
        if (!isSlotHoverd) {
            return;
        }
        isSlotHoverd = false;
        border.DOFade(0, 0.1f);
    }
}

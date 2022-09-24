using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlotComponent : MonoBehaviour
{
    public LaneComponent lane;
    public MinionComponent current_minion;
    public MinionComponent minionPrefab;

    bool isSlotHoverd;
    private Vector3 originalScale;
    private Vector3 upScale;

    public static SlotComponent selectedSlot;
    public void Start() {
        originalScale = transform.localScale;
        upScale = originalScale * 1.2f;
    }
    public void SetMinion(MinionComponent minion){
        if(null != current_minion){
            return;
        }

        current_minion = minion;

        //****something with ui nad positioning
    }

    public bool CreateMinion(Card_ScriptableObject card_so){
        if(current_minion)return false;
        MinionComponent minion = Instantiate(minionPrefab,transform);
        minion.InitiateMinion(card_so);
        return true;
    } 

    void OnMouseEnter()
    {
        if (isSlotHoverd) {
            return;
        }
        isSlotHoverd = true;
        transform.DOScale(upScale, 0.3f);
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            
        }
    }

    void OnMouseExit()
    {
        if (!isSlotHoverd) {
            return;
        }
        isSlotHoverd = false;
            transform.DOScale(originalScale, 0.3f);

    }
}

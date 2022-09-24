using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotComponent : MonoBehaviour
{
    public LaneComponent lane;
    public MinionComponent current_minion;

    public MinionComponent minionPrefab;



    void SetMinion(MinionComponent minion){
        if(current_minion)return;

        current_minion = minion;

        //****something with ui nad positioning
    }

    void CreateMinion(Card_ScriptableObject card_so){
        if(current_minion)return;
        MinionComponent minion = Instantiate(minionPrefab,transform);
        minion.InitiateMinion(card_so);
    } 
}

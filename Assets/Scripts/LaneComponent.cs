using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneComponent : MonoBehaviour
{
    public SlotComponent playerSlot,enemySlot;
    public EntityComponent playerTarget,enemyTarget;

    public MinionComponent playerMinion,enemyMinion;
    public void Attack(){
        if(playerSlot.current_minion)enemyTarget = playerSlot.current_minion;
        if(enemySlot.current_minion)playerTarget = enemySlot.current_minion;

        if(enemySlot.current_minion)
            enemyTarget.Hit(enemySlot.current_minion.cardSO.attackStrength);
        if(playerSlot.current_minion)
            playerTarget.Hit(playerSlot.current_minion.cardSO.attackStrength);
    }
}

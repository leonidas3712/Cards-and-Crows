using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneComponent : MonoBehaviour
{
    public SlotComponent playerSlot,enemySlot;

    [HideInInspector]
    public EntityComponent playerTarget,enemyTarget;
    [HideInInspector]
    public MinionComponent playerMinion,enemyMinion;
    public void Attack(){
        if (null != playerSlot.current_minion) {
            enemyTarget = playerSlot.current_minion;
        }
        else {
            enemyTarget = HeroComponent.playerHeroInstance;
        }
        if (null != enemySlot.current_minion) {
            playerTarget = enemySlot.current_minion;
        }
        else {
            playerTarget = HeroComponent.enemyHeroInstance;
        }

        if (null != enemySlot.current_minion) {
            enemyTarget.Hit(enemySlot.current_minion.cardSO.attackStrength);
        }
        if (null != playerSlot.current_minion) {
            playerTarget.Hit(playerSlot.current_minion.cardSO.attackStrength);
        }
        playerMinion = null;
        enemyMinion = null;
        playerTarget = null;
        enemyTarget = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaneComponent : MonoBehaviour
{
    public SlotComponent playerSlot, enemySlot;
    int activeSequences = 0;

    public bool Attack() {
        if(activeSequences != 0) {
            Debug.LogError("There are somehow " + activeSequences + " active sequences on this lane", this);
        }
        Sequence attackSequence;
        if (enemySlot.current_minion != null) {
            activeSequences++;

            attackSequence = enemySlot.current_minion.Attack();
            attackSequence.OnKill(
                () => {
                    activeSequences--;
                    if (activeSequences == 0) {
                        GameManagerComponent.laneBattleEndedEvent.Invoke();
                    }
                }
            );
        }
        if (playerSlot.current_minion != null) {
            activeSequences++;

            attackSequence = playerSlot.current_minion.Attack();
            attackSequence.OnKill(
                () => {
                    activeSequences--;
                    if (activeSequences == 0) {
                        GameManagerComponent.laneBattleEndedEvent.Invoke();
                    }
                }
            );
        }

        return activeSequences > 0;
    }
}

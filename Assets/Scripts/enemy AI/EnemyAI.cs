using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyHandComponent hand;
    public List<SlotComponent> slots;
    void Awake()
    {
        GameManagerComponent.enemyTurnStartedEvent.AddListener(
            () => {
                StartCoroutine(Play());
            }
        );
    }

    IEnumerator Play(){
        yield return new WaitForSeconds(1f);
        foreach(EnemyCardComponent card in hand.GetComponentsInChildren<EnemyCardComponent>()){
            yield return new WaitForSeconds(0.2f);
            if(hand.Mana-card.card_so.cost>=0){
                foreach(SlotComponent slot in slots){
                    if(slot.current_minion == null){
                        card.PlayCard(slot);
                        break;
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
        GameManagerComponent.enemyTurnEndedEvent.Invoke();
    }
}

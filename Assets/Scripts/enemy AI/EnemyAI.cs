using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        // Shuffle slots to be inconsistent
        int n = slots.Count;
        while (n > 1) {  
            n--;
            int k = Random.Range(0, n + 1);
            SlotComponent value = slots[k];
            slots[k] = slots[n];
            slots[n] = value;
        }  

        yield return new WaitForSeconds(1f);
        foreach(EnemyCardComponent card in hand.GetComponentsInChildren<EnemyCardComponent>()) {
            yield return new WaitForSeconds(0.2f);
            if (hand.Mana >= card.card_so.cost) {
                foreach (SlotComponent slot in slots) {
                    if (slot.current_minion == null) {
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

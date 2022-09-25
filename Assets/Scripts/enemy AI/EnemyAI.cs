using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyHandComponent hand;
    public List<SlotComponent> slots;
    void Start()
    {
        GameManagerComponent.enemyTurnStartedEvent.AddListener(Play);
    }

    public void Play(){
        foreach(EnemyCardComponent card in hand.cards){
            if(hand.Mana-card.card_so.cost>=0){
                foreach(SlotComponent slot in slots){
                    if(slot.current_minion == null){
                        card.PlayCard(slot);
                        break;
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckComponent : MonoBehaviour
{
 
    public CardComponent cardPrefab;
    [SerializeField]
    private List<Card_ScriptableObject> cards;
    [SerializeField]
    private string playerName;

    public Card_ScriptableObject DrawCard() {
        Debug.Log("There are " + cards.Count + " cards in " + playerName + "'s deck.");
        if (cards.Count == 0) {
            // TODO Trigger OnEmptyDeckDrawEvent
            return null;
        }
        int randomIndex = Random.Range(0, cards.Count - 1);
        Card_ScriptableObject card_so = Instantiate(cards[randomIndex]);
        cards.RemoveAt(randomIndex);
        return card_so;
    }
}

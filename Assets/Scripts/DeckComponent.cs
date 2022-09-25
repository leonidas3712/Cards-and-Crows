using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckComponent : MonoBehaviour
{
    public CardComponent cardPrefab;
    [SerializeField]
    private List<Card_ScriptableObject> cards;
    [SerializeField]
    public string playerName;
    public TextMeshProUGUI info;

    void Start() {
        info.text = playerName + " deck\n" + cards.Count + " cards.";
    }

    public Card_ScriptableObject DrawCard() {
        if (cards.Count == 0) {
            // TODO Trigger OnEmptyDeckDrawEvent
            return null;
        }
        int randomIndex = Random.Range(0, cards.Count - 1);
        Card_ScriptableObject card_so = Instantiate(cards[randomIndex]);
        cards.RemoveAt(randomIndex);
        if (cards.Count == 0) {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        Start();
        return card_so;
    }
}

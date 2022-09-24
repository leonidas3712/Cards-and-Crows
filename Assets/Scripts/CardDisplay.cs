using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card_ScriptableObject card_so;

    public Text nameText;
    public Text attributeText;
    public Image cardImage;

    public Text HP;
    public Text attackStrength;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(card_so.carndName);
        nameText.text = card_so.carndName;
        attributeText.text = card_so.attributes.ToString();

        cardImage.sprite = card_so.image;

        HP.text = card_so.hp.ToString();
        attackStrength.text = card_so.attackStrength.ToString();
        
    }
}

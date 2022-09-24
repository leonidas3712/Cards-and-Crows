using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardComponent : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI attributeText;
    public Image cardImage;

    public TextMeshProUGUI HP;
    public TextMeshProUGUI attackStrength;
    public void SetScriptableObject(Card_ScriptableObject card_so)
    {
        nameText.text = card_so.carndName;
        //attributeText.text = card_so.attributes.ToString();

        cardImage.sprite = card_so.image;

        HP.text = card_so.hp.ToString();
        attackStrength.text = card_so.attackStrength.ToString();
    }

    public void AdjustCardPosition()
    {
        
    }
}

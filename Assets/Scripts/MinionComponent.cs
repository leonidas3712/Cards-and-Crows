using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MinionComponent : EntityComponent
{
    public Card_ScriptableObject cardSO;
    List<Attribute> attributeList;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI attributeText;
    public Image minionImage;
    public TextMeshProUGUI uiHP;
    public TextMeshProUGUI attackStrength;
    public void InitiateMinion(Card_ScriptableObject card_so){
            this.cardSO = card_so;
            SetAttributes();
            HP = card_so.hp;
            nameText.text = card_so.cardName;
            //attributeText.text = card_so.attributes.ToString();
            minionImage.sprite = card_so.image;
            uiHP.text = card_so.hp.ToString();
            attackStrength.text = card_so.attackStrength.ToString();
        }
    public void SetAttributes()
    {
        attributeList = new List<Attribute>();
        foreach(GameObject attributeObject in cardSO.attributes){
           attributeList.Add(Instantiate(attributeObject,transform).GetComponent<Attribute>());
        }
        foreach(Attribute attribute in attributeList){
            attribute.RegisterAttribute();
        }
    }
    public override void Death() {
        Destroy(gameObject);
    }
}

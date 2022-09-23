using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionComponent : MonoBehaviour
{
    public Card_ScriptableObject cardSO;
    List<Attribute> attributeList;
    public void Awake()
    {
        attributeList = new List<Attribute>();
        foreach(GameObject attributeObject in cardSO.attributes){
           attributeList.Add(Instantiate(attributeObject,transform).GetComponent<Attribute>());
        }
        foreach(Attribute attribute in attributeList){
            attribute.RegisterAttribute();
        }
    }

  
}

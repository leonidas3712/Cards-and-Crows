using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Card_ScriptableObject", menuName = "VeryCozyFallJam2022/Card_ScriptableObject", order = 0)]
public class Card_ScriptableObject : ScriptableObject {
    public List <GameObject> attributes;
    public string carndName;
    public int attackStrength;
    public int hp;

    public Sprite image;
}


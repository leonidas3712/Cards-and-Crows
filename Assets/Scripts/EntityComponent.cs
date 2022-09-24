using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public abstract class EntityComponent : MonoBehaviour
{
    public int hp;

    public TextMeshProUGUI hpText;

    public int HP {
        get {
            return hp;
        }
        protected set {
            hp = value;
            hpText.text = hp.ToString();
        }
    }
    
    public void Hit(int damage) {
        HP = Math.Max(0, hp - damage);
    }

    public bool IsAlive() {
        return hp != 0;
    }
    public abstract void Death();
}

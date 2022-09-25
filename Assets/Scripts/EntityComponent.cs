using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public abstract class EntityComponent : MonoBehaviour
{
    public bool isAlive = true;
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
        if (!isAlive) {
            Debug.Log("Why do you hit a dead object?", this);
            return;
        }
        HP = Math.Max(0, hp - damage);
        if (hp <= 0) {
            isAlive = false;
            Death();
        }
    }

    public bool IsAlive() {
        return isAlive;
    }

    public abstract void Death();
}

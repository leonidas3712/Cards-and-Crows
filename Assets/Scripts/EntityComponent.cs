using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public abstract class EntityComponent : MonoBehaviour
{
    private bool isAlive = true;
    private bool hasDied = false;
    public int hp;

    public TextMeshProUGUI hpText;

    public virtual void Awake() {
        GameManagerComponent.laneBattleEndedEvent.AddListener(
            () => {
                if (!isAlive && !hasDied) {
                    hasDied = true;
                    Death();
                }
            }
        );
    }

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
        }
    }

    public bool IsAlive() {
        return isAlive;
    }

    public abstract void Death();
}

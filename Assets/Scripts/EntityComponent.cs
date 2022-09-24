using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class EntityComponent : MonoBehaviour
{
    [SerializeField]
    public int hp;

    public TextMeshProUGUI hpText;

    public void updateUI()
    {
        hpText.text = hp.ToString();
    }
    public int HP {
        get {
            return hp;
        }
    }
    
    public void Hit(int damage) {
        hp = Math.Max(0, hp - damage);
        this.updateUI();
    }

    public bool IsAlive() {
        return hp != 0;
    }
    public virtual void Death(){

    }
}

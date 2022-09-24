using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class EntityComponent : MonoBehaviour
{
    private int hp;
    public int HP {
        get {
            return hp;
        }
    }
    
    public void Hit(int damage) {
        hp = Math.Max(0, hp - damage);
    }

    public bool IsAlive() { 
        return hp != 0;
    }
}

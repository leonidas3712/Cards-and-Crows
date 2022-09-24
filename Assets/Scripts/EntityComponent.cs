using System.Collections;
using System.Collections.Generic;
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
        hp -= damage; 
    }
}

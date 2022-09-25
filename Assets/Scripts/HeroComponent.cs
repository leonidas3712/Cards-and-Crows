using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HeroComponent : EntityComponent
{
    public static HeroComponent playerHeroInstance;
    public static HeroComponent enemyHeroInstance;

    public int DEFAULT_HP_AMOUNT = 30;

    [SerializeField]
    private bool _isPlayerHero; // Do not modify! (Modified within Editor)
    public bool IsPlayerHero {get { return _isPlayerHero;}}

    public override void Awake() {
        base.Awake();
        if (IsPlayerHero) {
            if (playerHeroInstance != null) {
                throw new SystemException("Player hero was created twice");
            }
            playerHeroInstance = this;
        } else {
            if (enemyHeroInstance != null) {
                throw new SystemException("Enemy hero was created twice");
            }
            enemyHeroInstance = this;
        }
        HP = DEFAULT_HP_AMOUNT;
    }

    public override void Death() {
        if (IsPlayerHero) {
            GameManagerComponent.Instance.QueueMessage("DEFEAT", 2);
        } else {
            if (playerHeroInstance.IsAlive()) {
                GameManagerComponent.Instance.QueueMessage("VICTORY", 2);
            }
        }
    }

    // Start is called before the first frame update
    void Start() {

    }
}

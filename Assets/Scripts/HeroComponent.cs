using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HeroComponent : EntityComponent
{
    public static HeroComponent playerHeroInstance;
    public static HeroComponent enemyHeroInstance;

    public int DEFAULT_HP_AMOUNT = 20;

    [SerializeField]
    private bool _isPlayerHero; // Do not modify! (Modified within Editor)
    public bool IsPlayerHero {get { return _isPlayerHero;}}

    void Awake() {
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
        this.hp = DEFAULT_HP_AMOUNT;
        this.updateUI();
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}

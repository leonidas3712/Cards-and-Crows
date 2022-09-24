using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroComponent : EntityComponent
{
    public static HeroComponent playerHeroInstance;
    public static HeroComponent enemyHeroInstance;

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
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackManager : MonoBehaviour
{
    public GameObject atkObj; //エフェクト
    public GameObject atkCollider; //当たり判定

    [SerializeField]
    private int attacktype; //攻撃の種類

    private int attack; //攻撃力

    [SerializeField]
    private GameObject rootobj;

    public void init(int attack){
        this.attack = attack;

        
        atkCollider.AddComponent<AttackObjManager>();
        atkCollider.GetComponent<AttackObjManager>().setType(attacktype,attack);

        GameSettings.printLog("[AttackManager] attack : " + attack);
    }

    public void Attack(String name)
    {
        switch(name){
            case "shoot":
                atkCollider.transform.localScale = 3.0f * atkCollider.transform.localScale;
                break;
            case "laser":
                atkCollider.transform.localScale = 5.0f * atkCollider.transform.localScale;

                break;
            case "thunder":
                break;
            case "poison":
                atkCollider.transform.localScale = 2.0f * atkCollider.transform.localScale;
                break;
            case "meteo":
                atkCollider.transform.localScale = 3.0f * atkCollider.transform.localScale;
                break;
        }
        ParticleSystem p = atkObj.GetComponent<ParticleSystem>();
        p.Play();
        atkCollider.GetComponent<Animator>().Play(name, -1, 0);
    }


    private void OnParticleSystemStopped()
    {

        Destroy(rootobj);
    }

}
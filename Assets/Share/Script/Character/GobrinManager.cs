﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobrinManager : StatueManager
{
    [SerializeField]
    protected GobrinData gobrin; //自分のパラメータ

    void Start()
    {
        isStatue = false;

        time = 0.0f;
       // enemylist = new List<GameObject>();

        gp = GameObject.FindWithTag("GameManager").GetComponent<GameProgress>();

        if(isDebug){
      //    gstatus.hp = statue.hp;
        }
    }

    void Update()
    {
        if(gp.getStatus() != gp.NOW_GAME)return;


        if(hpbar != null){
             hpbar.fillAmount = gstatus.hp / (float)gobrin.hp;
        }
    }

    public override void Generate(Vector3 pos,Vector3 scale,StatueData f){
        if(gp == null){
          gp = GameObject.FindWithTag("GameManager").GetComponent<GameProgress>();
        }
        hpbar.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z);
        hpbar.fillAmount = 1;

        gstatus.hp = gobrin.hp;

    }

    public override void Dead(){
      Destroy(this.gameObject);
    }


    public override StatueData getSData(){
      return gobrin;
    }

    public override GobrinData getGData(){
      return null;
    }

    public override void checkEnemy(){
      //NOP
    }

    public override　void addHP(int hp){
      hiteffect.Play(true);
      gstatus.hp += hp;
    }


    public override void setNum(bool isgenerate){
    }


}
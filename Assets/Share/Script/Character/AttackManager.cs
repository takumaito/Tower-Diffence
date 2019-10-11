﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackManager : MonoBehaviour
{
    public GameObject atkObj; //エフェクト
    public GameObject atkCollider; //当たり判定
    float time;
    public Boolean notRotate; //親オブジェクトと一緒に回転させないか

    [SerializeField]
    private int attacktype; //攻撃の種類

    private int attack;

    private bool isset;

    void Start()
    {
        isset = false;
    }

    public void init(int attack){
        this.attack = attack;
        time = 0.0f;
        atkCollider.AddComponent<AttackObjManager>();
        atkCollider.GetComponent<AttackObjManager>().setType(attacktype,attack);
        isset = true;

        GameSettings.printLog("[AttackManager] attack : " + attack);
  
    }

    void Update()
    {
        if(!isset)return;


        time += Time.deltaTime;

        if (time > 5.0f)
        {
            time = 0;

        }

        if (notRotate)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Attack(String name)
    {
        ParticleSystem p = atkObj.GetComponent<ParticleSystem>();
        p.Play();
        atkCollider.GetComponent<Animator>().Play(name, -1, 0);
    }


    private void OnParticleSystemStopped()
    {
        transform.parent.gameObject.GetComponent<FacilityManager>().attackEnd();

        Destroy(this.gameObject);
    }


    void OnDrawGizmos()
    {
        //  if(isDebug){    
        //  Gizmos.color = Color.green;
        // Gizmos.DrawSphere( transform.position, 0.1f );
        // Gizmos.DrawWireSphere( transform.position, Radius );
        // }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private GameObject rootobj;
    // Start is called before the first frame update
    void Start()
    {
          rootobj = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other){
      rootobj.GetComponent<FacilityManager>().EnemyOnArea(other.gameObject);
    }
}
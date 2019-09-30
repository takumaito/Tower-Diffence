using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Linq;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour
{
    protected GameProgress gp;
    [SerializeField]
    private int hp;
    [SerializeField]
    private Image hpbar;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private String deadName;

    private float time;

    void Start(){
      gp = GameObject.FindWithTag("GameManager").GetComponent<GameProgress>();
      time = 0.0f;
    }

    void Update(){
      if(gp.getStatus() != gp.NOW_GAME)return;

      time += Time.deltaTime;
    
      hpbar.fillAmount = 1 - (time /(float)hp);

    }

    public void Dead(){
        Debug.Log("dead crystal!");
       // this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        canvas.SetActive(false);

        GameObject deadobj = ResourceManager.getObject("Crystal/" + deadName);
        GameObject obj = Instantiate(deadobj,transform.position,Quaternion.identity) as GameObject;

        obj.transform.parent = this.transform;

        obj.transform.localPosition = deadobj.transform.position;
        obj.transform.localScale = deadobj.transform.localScale;
        obj.transform.localRotation = deadobj.transform.localRotation;
        ParticleSystem p = obj.GetComponent<ParticleSystem>();
        p.Play();

        Destroy(this.gameObject,2);

    }

    public float getHP(){
        return hpbar.fillAmount;
    }
}
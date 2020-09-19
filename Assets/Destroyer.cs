using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
    public int point;
    public GameObject masterObj;

    public int initHp;
    private int currentHp;
 
    public AudioClip hitSE;
    public AudioClip DestroySE;

    void Start () 
    {
	this.currentHp = initHp;
    }

    private void OnCollisionEnter(Collision collision)
   {
        this.currentHp -= 1;
    
    
    if(this.currentHp <= 0)
    {
        AudioSource.PlayClipAtPoint(DestroySE,transform.position);
        
        masterObj.GetComponent<GameMaster>().boxNum--;

        FindObjectOfType<Score>().AddPoint(point);
        
        Destroy(this.gameObject);
    }
    else
    {
        AudioSource.PlayClipAtPoint(hitSE,transform.position);
    }
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger2 : MonoBehaviour
{
    public Animator kapı;
    public GameObject obj;
    
    void Start()
    {
        kapı.GetComponent<Animator>();
    }

     void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "karakter")
        {
            kapı.Play("kapıanim");

        }
       
    }

     void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "karakter")
        {
            kapı.Play("kapanmaanim");
        } 

    }


    void Update()
    {
        
    }
}

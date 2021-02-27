using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trigger : MonoBehaviour
{
    public GameObject npcpozisyonu,kullanıcı;
    public Animator kapı,npc;
    [SerializeField]
    private Transform[] controlpoints;    
    private Vector3 küppozisyonu,mesafe;
    private Coroutine ilkrota;
    bool ilkupdate = true;
    private float hızdeğiştirme, tparametresi;
    void Start()
    {
        tparametresi = 0f;
        hızdeğiştirme = 0.1f;          
        kapı.GetComponent<Animator>();
        npc.GetComponent<Animator>();
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "varısnokta")
        {

            npc.SetBool("geçiş2", true);
            Debug.Log("çarptı");
         
           
        }
       
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Cube")
        {
                    
            
        }

    }
    
    void Update()
    {
        

        if (kullanıcı.transform.position.x < 14.3 &&  ilkupdate)
        {
            kapı.Play("kapı2ac");
            ilkrota =StartCoroutine(rotayıtakip());
            ilkupdate = false;
        }
            
    }
    
    IEnumerator rotayıtakip()
    {
        yield return new WaitForSeconds(1);
        npc.SetBool("geçiş1", true);
      
        while (tparametresi < 1)
        {
            tparametresi += Time.deltaTime * hızdeğiştirme;
            küppozisyonu = Mathf.Pow(1 - tparametresi, 3) * controlpoints[0].position +
                3 * Mathf.Pow(1 - tparametresi, 2) * tparametresi * controlpoints[1].position +
                3 * (1 - tparametresi) * Mathf.Pow(tparametresi, 2) * controlpoints[2].position +
                Mathf.Pow(tparametresi, 3) * controlpoints[3].position;
            npcpozisyonu.transform.position = küppozisyonu;
          

            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
                      
    }
    
}


    




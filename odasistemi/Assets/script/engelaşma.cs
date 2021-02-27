using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engelaşma : MonoBehaviour
{
    public LayerMask engel;
    private float range;
    private float hız;
    public GameObject target,masa;
    private float dönmehızı,arkarange,yaklaşma,arkauzunluk;
    private RaycastHit hit;
    private bool varmı=false;    
    Vector3 mesafe;
    void Start()
    {
        range =4f;
        hız = 2.5f;
        dönmehızı = 90f;
        arkarange = 4f;
        yaklaşma = 0.1f;
        arkauzunluk = 3f;
    }

   
    void Update()
    {
       
            if (!varmı)
            {

                Vector3 relativepos = target.transform.position - transform.position;
                 mesafe = relativepos;

             Quaternion rotation = Quaternion.LookRotation(relativepos);

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*45);
            }

            
            float uzunluk = Vector3.Magnitude(mesafe);
         if (uzunluk>= yaklaşma)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * hız);          
        }
        if (uzunluk < yaklaşma)
        {
            transform.LookAt(masa.transform);
            varmı = false;
        }

            Transform solışın = transform;
            Transform sağışın = transform;


        if (Physics.Raycast(solışın.position + (transform.right * 1), transform.forward, out hit, range,engel) ||
                    (Physics.Raycast(sağışın.position - (transform.right * 1), transform.forward, out hit, range,engel)) ||
                    (Physics.Raycast(transform.position, transform.forward, out hit, range,engel)))
            {
               // if (hit.collider.gameObject.CompareTag("engeller"))
                //{
                    varmı = true;
                    transform.Rotate(Vector3.up * Time.deltaTime * dönmehızı);
            hız = 2f;
                    Debug.Log("deydi");
                //}
            }
        


        if (Physics.Raycast(transform.position - (transform.forward * 4), transform.right, out hit, 0,engel) ||
                    (Physics.Raycast(transform.position - (transform.forward * arkauzunluk), -transform.right, out hit, arkarange,engel)))
            {
              //  if (hit.collider.gameObject.CompareTag("engeller"))
                //{
                    varmı = false;
            hız = 2.5f;
                //}
            
        }





        if (Physics.Raycast(solışın.position - (transform.right * 1), -transform.right, out hit, 1,engel) ||
            (Physics.Raycast(transform.position-(transform.forward*2) , -transform.right, out hit, 2,engel))) {
          //  if (hit.collider.gameObject.CompareTag("engeller"))
           // {
                varmı = true;
              //  transform.Rotate(Vector3.up * Time.deltaTime * dönmehızı);
                Debug.Log("deydi");
           // }
        }
        

        if (Physics.Raycast(solışın.position + (transform.right * 1), transform.forward, out hit, range, engel) ||
                   (Physics.Raycast(sağışın.position - (transform.right * 1), transform.forward, out hit, range, engel)) ||
                   (Physics.Raycast(transform.position, transform.forward, out hit, range, engel)) && 
                   (Physics.Raycast(transform.position - (transform.forward * arkauzunluk), -transform.right, out hit, arkarange, engel)))
        {
            varmı = true;
            transform.Rotate(Vector3.up * Time.deltaTime * dönmehızı);
            hız = 2f;
            Debug.Log("deydi");
        }





        /*
            Debug.DrawRay(transform.position + (transform.right * 1), transform.forward * range, Color.blue);
        Debug.DrawRay(transform.position - (transform.right * 1), transform.forward * range, Color.red);
        Debug.DrawRay(transform.position - (transform.forward * arkauzunluk), -transform.right * arkarange, Color.yellow);
        Debug.DrawRay(transform.position - (transform.forward * 5), transform.right * 0, Color.yellow);

        Debug.DrawRay(solışın.position - (transform.right * 1), -transform.right * 1, Color.green);
        Debug.DrawRay(transform.position-(transform.forward) , -transform.right * 2, Color.green);
        */
    }
    
}

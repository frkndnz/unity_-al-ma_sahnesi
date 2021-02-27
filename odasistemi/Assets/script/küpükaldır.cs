using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class küpükaldır : MonoBehaviour
{
    public GameObject küp;
    public GameObject sağel;
    public Transform parent;
    Vector3 küporjinalpoz;
    Quaternion küporjinalrot;



    void Start()
    {
        if(küp != null)
        {
            küporjinalpoz = küp.transform.position;
            küporjinalrot = küp.transform.rotation;
        }


    }
    public void Kaldır()
    {    if(küp != null)
        {
            Vector3 distance = küp.transform.position - sağel.transform.position;
            float magnitude = distance.magnitude;
            if(magnitude<= 1f)
            {
                küp.transform.SetParent (parent);
                küp.transform.localPosition = Vector3.zero;
            }

        }

    }




    
    void Update()
    {
        
    }
}

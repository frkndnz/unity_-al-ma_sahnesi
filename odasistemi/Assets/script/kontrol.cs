using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kontrol : MonoBehaviour
{
   public float hız = 4;
   // float dönmehız = 80;
   // float yercekimi = 8;
    Vector3 movedir = Vector3.zero;
    CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 move = transform.right * yatay + transform.forward * dikey;
        controller.Move(move * hız * Time.deltaTime);



    }
}

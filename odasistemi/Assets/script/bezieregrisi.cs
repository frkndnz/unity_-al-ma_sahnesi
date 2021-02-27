using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bezieregrisi : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlpoints;
    private Vector3 pozisyon;
    
    void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        for(float t=0;t<=1; t += 0.05f)
        {
            pozisyon = Mathf.Pow(1 - t, 3) * controlpoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * controlpoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlpoints[2].position + Mathf.Pow(t, 3) * controlpoints[3].position;
            Gizmos.DrawSphere(pozisyon, 0.25f);


        }
    }






    // Update is called once per frame
    void Update()
    {
        
    }
}

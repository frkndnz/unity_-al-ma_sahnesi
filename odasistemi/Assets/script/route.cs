using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class route : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;
    private int routetoGo;
    private float tparametresi,hızdeğiştirme;
    private Vector3 küppozisyonu;
    private bool coroutineallowed;
    void Start()
    {
        routetoGo = 0;
        tparametresi = 0f;
        hızdeğiştirme = 0.5f;
        coroutineallowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineallowed)
        {
            StartCoroutine(GoByTheRoute(routetoGo));
        }

    
    }
        private IEnumerator GoByTheRoute(int routenumber)
    
    {
        coroutineallowed = false;
        Vector3 p0 = routes[routenumber].GetChild(0).position;
        Vector3 p1 = routes[routenumber].GetChild(1).position;
        Vector3 p2 = routes[routenumber].GetChild(2).position;
        Vector3 p3 = routes[routenumber].GetChild(3).position;
        while (tparametresi < 1)
        {
            tparametresi += Time.deltaTime * hızdeğiştirme;
            küppozisyonu = Mathf.Pow(1 - tparametresi, 3) * p0 +
                3 * Mathf.Pow(1 - tparametresi, 2) * tparametresi * p1 +

                3 * (1 - tparametresi) * Mathf.Pow(tparametresi, 2) * p2 +
                Mathf.Pow(tparametresi, 3) * p3;
            transform.position = küppozisyonu;


            yield return new WaitForEndOfFrame();
        }
    }



}

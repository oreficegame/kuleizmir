using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class fare : MonoBehaviour
{
    public float limon = 1f;
    private Light2D light;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "annen")
        {
            light.pointLightOuterRadius += limon;
            
        }
    }
    private void Awake()
    {
        light = GetComponent<Light2D>();
    }
    private void Start()
    {

    }


    void Update()
    {
       
    }
}

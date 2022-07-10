using System;
using System.Collections;
using System.Collections.Generic;
using HQFPSTemplate;
using UnityEngine;

public class Death : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageInfo damage = new DamageInfo(-1000f);
        other.GetComponent<Player>().ChangeHealth.Try(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

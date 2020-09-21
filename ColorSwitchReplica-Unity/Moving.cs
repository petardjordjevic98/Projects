using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    public float move = 4f;
    public static bool smer = false;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 6.2)
            smer = true;
        if (transform.position.x < -6.2f)
            smer = false;
       
        if (!smer)
        transform.position = new Vector3(transform.position.x + move*Time.deltaTime, transform.position.y, transform.position.z);      
    
    else 
            transform.position = new Vector3(transform.position.x - move * Time.deltaTime, transform.position.y, transform.position.z);
        
    }
}

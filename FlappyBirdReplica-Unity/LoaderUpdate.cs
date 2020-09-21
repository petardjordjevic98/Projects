using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderUpdate : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Update()
    {
        Debug.Log("P");

        Loader.LoadTargetScene();
    }
}

//Bismillah
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    RaycastHit Nesne;
    public bool Hasarvur;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Hasarvur=true;
        }
    }
    void FixedUpdate()
    {
        if(Hasarvur)
        {
            if(Physics.Raycast(Camera.main.gameObject.transform.position, Camera.main.gameObject.transform.forward, out Nesne, 150f))
            {
                if(Nesne.transform.tag == "Dusman")
                {
                    Destroy(Nesne.transform.gameObject);
                }

            }
            Hasarvur=false;
        }
        
    }
}

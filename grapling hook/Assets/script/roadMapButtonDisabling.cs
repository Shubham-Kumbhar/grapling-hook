using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class roadMapButtonDisabling : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private GameObject child;
    // Update is called once per frame
    void Update()
    {
        Disable();

    }

    private void Disable()
    { 
            for (int i = 0; i <= level; i++)
            {
                child = transform.GetChild(i).gameObject;
                child.SetActive(true);
            }
        
       
    }
}

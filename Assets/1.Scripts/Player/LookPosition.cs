using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookPosition : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
         
    }
}
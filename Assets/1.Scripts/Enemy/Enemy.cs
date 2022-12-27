using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Sprite HPbarImage;
    [SerializeField] private TMP_Text HPTxt;
    [SerializeField] private TMP_Text DamageTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("PAttack"))
        {
            //Destroy(gameObject);
        }
    }
}

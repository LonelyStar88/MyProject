using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    Transform Target;
    Transform parent;

    float speed;
    float dis;
    float time;
    //public bool isAttack = true;

    public void Init()
    {
        speed = 2f;
        time = 0f;
    }

    public void SetParent(Transform trans)
    {
        parent = trans;
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Target == null)
        {
            return;
        }
        else
        {
            dis = Vector3.Distance(transform.position, Target.transform.position);
        }
        this.transform.position = Vector2.MoveTowards(this.transform.position, Target.position, Time.deltaTime * speed);
        
    }


  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"Damage : {collision.GetComponent<Player>().damage}");
        if(collision.tag.Equals("PAttack"))
        {
            Destroy(gameObject);
        }
        else if(collision.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Image HPbarImage;
    [SerializeField] private TMP_Text HPTxt;
    [SerializeField] private TMP_Text DamageTxt;
    [SerializeField] private Transform Target;
    float CurHP;
    float MaxHP;
    float speed = 0.5f;
    float dis;
    float time = 0f;
    public bool isAttack = true;
    public float EnemyDamage
    {
        get; set;
    }
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100f;
        CurHP = MaxHP;
        HPTxt.text = string.Format($"{0}/{1}",CurHP,MaxHP);
        EnemyDamage = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Target != null)
        {
            dis = Vector3.Distance(transform.position, Target.transform.position);
            
        }
        HPbarImage.fillAmount = CurHP / MaxHP;
        HPTxt.text = string.Format($"{0}/{1}", CurHP, MaxHP);
        if (dis > 1f)
        {
            //this.transform.LookAt(target);
            this.transform.position = Vector2.MoveTowards(this.transform.position, Target.position, Time.deltaTime * speed);
            //transform.Translate(Target.position * Time.deltaTime * speed);
        }
        else
        {
            if(!isAttack)
            {
                time = 0f;
                isAttack = true;
            }
        }

        if(!isAttack && time > 5f)
        {
            time = 0f;
            isAttack = true;
        }
        
    }

    public void Damage(float damage)
    {
        CurHP -= damage;
        if (CurHP > 0)
        {
            StartCoroutine(Damaged(damage));
            CurHP = 0;
        }
        
    }
  
    
    IEnumerator Damaged(float damage)
    {
        DamageTxt.text = damage.ToString();
        DamageTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DamageTxt.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Damage : {collision.GetComponent<Player>().damage}");
        if(collision.tag.Equals("PAttack"))
        {
            Damage(collision.GetComponent<Player>().damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log($"Damage : {collision.GetComponent<Player>().damage}");
        if (collision.tag.Equals("PAttack"))
        {
            Damage(collision.GetComponent<Player>().damage);
        }
    }
}

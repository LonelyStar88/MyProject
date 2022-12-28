using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
    [SerializeField]private Transform cameraTrans;
    [SerializeField]private Animator animator;
    [SerializeField] private Image HPbarImage;
    [SerializeField] private TMP_Text HPTxt;
    [SerializeField] private TMP_Text DamageTxt;
    float CurHP = 0;
    float MaxHP = 100;
    float speed = 3f;
    public float damage
    {
        get; set;
    }
    //bool isIdle;
    //bool isMove;
    bool isside;
    bool isdown;
    bool isup;

    void Awake()
    {
        CurHP = MaxHP;
    }
    // Start is called before the first frame update
    void Start()
    {
        isside = false;
        isdown = true;
        isup = false;
        damage = 10f;
        //MaxHP = 100;
        //CurHP = MaxHP;
        HPTxt.text = string.Format($"{0}/{1}", CurHP, MaxHP);
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라
        Vector3 cameraPos = new Vector3(transform.position.x, cameraTrans.position.y, cameraTrans.position.z);
        cameraTrans.position = cameraPos;

        //캐릭터 이동범위
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float ClampX = Mathf.Clamp(transform.position.x + x, -22.8f, 22.8f);

        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float ClampY = Mathf.Clamp(transform.position.y + y, -11.3f, 11.3f);

        transform.position = new Vector3(ClampX, ClampY, 0);

        // 캐릭터 이동에 따른 애니메이션 작업
        if (x == 0 && y == 0)
        {
            //멈춰있는 상태
            Animation("Idle");
        }
        else
        {
            if (x == 0 && y > 0) //위로 갈 경우
            {
                isside = false;
                isdown = false;
                isup = true;
                Animation("Up");
                transform.localRotation = Quaternion.Euler(0, 0f, 0);
               
            }
            else if(x == 0 && y < 0)//아래로 갈 경우
            {
                isside = false;
                isdown = true;
                isup = false;
                Animation("Down");
                transform.localRotation = Quaternion.Euler(0, 0f, 0);
            }
            else if(x > 0) // 왼쪽으로 갈 경우
            {
                isside = true;
                isdown = false;
                isup = false;
                Animation("Side");
                transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }
            else if(x < 0) // 오른쪽으로 갈 경우
            {
                isside = true;
                isdown = false;
                isup = false;
                Animation("Side");
                transform.localRotation = Quaternion.Euler(0, 0f, 0);
            }    
        }

        // 공격
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Attack");
        }

        //HP표시
        HPbarImage.fillAmount = CurHP / MaxHP;
        HPTxt.text = string.Format($"{0}/{1}", CurHP, MaxHP);

    }

    public void Animation(string aniName)
    {
        animator.SetTrigger(aniName);
    }
    IEnumerator Attack()
    {
        if (isdown)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        if(isup)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            {
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        if(isside)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            {
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

    }
    IEnumerator PlayerDamaged()
    {
        transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>().isAttack)
        {
            DamageTxt.text = collision.GetComponent<Enemy>().EnemyDamage.ToString();
            StartCoroutine("PlayerDamaged");
            CurHP -= collision.GetComponent<Enemy>().EnemyDamage;
            collision.GetComponent<Enemy>().isAttack = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>().isAttack)
        {
            DamageTxt.text = collision.GetComponent<Enemy>().EnemyDamage.ToString();
            StartCoroutine("PlayerDamaged");
            CurHP -= collision.GetComponent<Enemy>().EnemyDamage;
            collision.GetComponent<Enemy>().isAttack = false;
        }
    }
}

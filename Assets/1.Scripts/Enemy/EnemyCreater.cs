using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    [SerializeField] private Transform Parent;
    [SerializeField] private Transform[] point;
    float ZenTime = 0f;
    int pointIDX = 0;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform Target;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        ZenTime += Time.deltaTime;
        Rezen();
    }

    void Rezen()
    {
        if (ZenTime > 1f) // 1초마다 적 생성
        {
            ZenTime = 0f;
            pointIDX = Random.Range(0, point.Length - 1);
            Debug.Log($"Index :{pointIDX}");
            GameObject objenemy = Instantiate(enemy, point[pointIDX]);
            if (objenemy != null)
            {
                objenemy.GetComponent<Enemy>().Init();
                objenemy.GetComponent<Enemy>().SetParent(Parent);
                objenemy.GetComponent<Enemy>().SetTarget(Target);
            }
            else
            {
                return;
            }
        }
    }
    
}

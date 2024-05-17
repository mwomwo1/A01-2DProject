using UnityEngine;


public class NormalEnemy : MonoBehaviour
{
    public GameObject normalEnemy;
    public EnemyData enemy = new(1, 0.03f);


    //GameManager로 이동할 코드
    void Start()
    {
        //Application.targetFrameRate = 60;
        //InvokeRepeating("MakeEnemy", 0f, 3f);
        MakeEnemy();
    }

    void Update()
    {
        MoveEnemy(enemy);
    }

    private void MakeEnemy()
    {
        // 일반 타입 enemy를 화면 상단에 랜덤 생성(배치)
        //Instantiate(normalEnemy);

        Debug.Log("화면 상단에 적 랜덤 생성");

        float x = Random.Range(-3.0f, 3.0f);
        float y = 5.0f;
        transform.position = new Vector3(x, y);
    }

    private void MoveEnemy(EnemyData enemy)
    {
        // 살아있는 적 기본 이동(하강)

        if (enemy.Hp > 0)
        {
            transform.position += Vector3.down * enemy.Speed;
            if (transform.position.y < -4.0f)
            {
                Debug.Log("화면 최하단에 도달한 적 오브젝트를 파괴합니다.");
                Destroy(normalEnemy, 3.0f);
            }
        }
    }

    private void Attack()
    {
        // 총알 생성 함수 호출하기
    }

    //충돌 감지

    private void DestoryEnemy() { }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 살아 있을 때 player의 bullet에 맞으면
            // Hp가 줄고 player의 bullet을 파괴한다

            if (enemy.Hp > 0)
            {
                enemy.Hp -= 1;
                Destroy(collision.gameObject);
            }
            else if (enemy.Hp == 0)
            {
                Destroy(normalEnemy, 3.0f);
                //GameManager.Instance.AddScore();
            }

            //플레이어와 충돌 시에도 피해 줌
        }
    }
}
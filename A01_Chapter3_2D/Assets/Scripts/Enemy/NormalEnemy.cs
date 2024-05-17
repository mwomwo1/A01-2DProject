using UnityEngine;


public class NormalEnemy : MonoBehaviour
{
    public GameObject normalEnemy;
    public EnemyData enemy = new(1, 0.01f);

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        MoveEnemy(enemy);
    }

    // �Ϲ� �� ����

    private void SpawnEnemy()
    {
        Debug.Log("ȭ�� ��ܿ� �� ���� ����");

        float x = Random.Range(-2.5f, 2.5f);
        float y = 5.0f;
        transform.position = new Vector3(x, y);
    }

    private void MoveEnemy(EnemyData enemy)
    {
        // ����ִ� �� �⺻ �̵�(�ϰ�)

        if (enemy.Hp > 0)
        {
            transform.position += Vector3.down * enemy.Speed;
            if (transform.position.y < -5.0f)
            {
                Debug.Log("ȭ�� ���ϴܿ� ������ �� ������Ʈ�� �ı��մϴ�.");
                Destroy(normalEnemy, 3.0f);
            }
        }
    }

    private void Attack()
    {
        // �Ѿ� ���� �Լ� ȣ���ϱ�
    }

    //���� �浹 ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // ��� ���� �� player�� bullet�� ������
            // Hp�� �ٰ� player�� bullet�� �ı��Ѵ�

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

            // TODO: �÷��̾�� �浹 �ÿ��� ���� ��

            // TODO: (HP�� 1 �̻��� ����) HP�� 1 �������� ���� ���� ������

        }
    }
}
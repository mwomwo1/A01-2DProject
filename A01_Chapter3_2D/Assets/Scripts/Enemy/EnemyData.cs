using UnityEngine;

public class EnemyData // : MonoBehaviour
{
    //�� ������
    public int Hp { get; set; } // �� �� �ǰ��ϸ� �ı��Ǵ��� 1~3
    public float Speed { get; set; } // �̵� �ӵ�


    public EnemyData(int hp, float speed)
    {
        Hp = hp;
        Speed = speed;
    }
}

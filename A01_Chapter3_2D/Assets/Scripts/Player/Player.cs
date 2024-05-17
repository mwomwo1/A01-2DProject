using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        //키보드 wasd 받기 x값 y값 받기
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 curPos = transform.position;
        Vector3 nextPos = (new Vector3(x, y, 0)).normalized * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }
}

﻿using System.Collections;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    //아이템이 특정 시간대에 세가지중에 랜덤으로 하나 생성되게 하기    

    public GameObject[] itemPrefabs;     

    private void Start()
    {
        // 최초 아이템 생성 스타트
        StartCoroutine(SpawnRandomItem());
    }

    private IEnumerator SpawnRandomItem()
    {
        while (true)
        {
            // 랜덤한 시간 대기
            float spawnInterval = Random.Range(15f, 40f);
            yield return new WaitForSeconds(spawnInterval);

            // 랜덤한 위치에 랜덤한 아이템을 생성
            float randomX = Random.Range(-2.5f, 2.5f);
            Vector2 spawnPosition = new Vector3(randomX, 4.7f);
            int randomIndex = Random.Range(0, itemPrefabs.Length);
            GameObject newItem = Instantiate(itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);

            ItemController.Instance.RandomItem(newItem);
                       
            Destroy(newItem, 10f); // 7초 후에 아이템 삭제
        }
    }
}

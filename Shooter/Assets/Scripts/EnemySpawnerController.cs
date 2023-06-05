using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public CanvasController CanvasController;
    public GameObject[] enemy=new GameObject[]{};
    public GameObject[] enemy1= new GameObject[] {};
    public GameObject enemy3;
    private float _time,_time1, _time2;
    private bool isSpawned, isSpawned1;
    public bool isSpawned2;
    
    void Start()
    {
        isSpawned = false;
        isSpawned1 = false;
        isSpawned2 = false;
    }


    void Update()
    {
        _time = Random.Range(4f, 6f);
        _time1 = Random.Range(5f, 9f);
        _time2 = Random.Range(3f, 5f);
        if (isSpawned2)
        {
            isSpawned2 = false;
            StartCoroutine(SpawnEnemys(_time));
        }
        if (CanvasController.deadEnemyValue>=24 && !isSpawned)
        {
            isSpawned =true;
           
            StartCoroutine(SpawnEnemys1(_time1));
        }
        if (CanvasController.deadEnemyValue>=60 && !isSpawned1)
        {
            isSpawned1 = true;
            StartCoroutine(SpawnEnemys2(_time2));
        }
      
    }
    public IEnumerator SpawnEnemys(float time)
    {
        while(true)
        {
            time = _time;
            int randomIndex=Random.Range(0, enemy.Length);
            Instantiate(enemy[randomIndex],new Vector3(Random.Range(-35,35),0,35),Quaternion.identity,transform);
            yield return new WaitForSeconds(time);
        }
    }
    public IEnumerator SpawnEnemys1(float time)
    {

            while (true)
            {
                time = _time1;
                int randomIndex = Random.Range(0, enemy1.Length);
                Instantiate(enemy1[randomIndex], new Vector3(Random.Range(-35, 35), 0, 35), Quaternion.identity, transform);
                yield return new WaitForSeconds(time);
            }
  
    }
    public IEnumerator SpawnEnemys2(float time)
    {
        while (true)
        {
            time = _time2;
            Instantiate(enemy3, new Vector3(Random.Range(-35, 35), 0, 35), Quaternion.identity, transform);
            yield return new WaitForSeconds(time);
        }
    }

}

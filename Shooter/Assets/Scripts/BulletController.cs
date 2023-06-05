using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    private Vector3 _dir;
    public EnemyController enemyController;


 

    void Start()
    {
       
    }


    void Update()
    {
        BulletMovement();
       
    }
    public void BulletMovement()
    {
        
        transform.Translate(_dir*bulletSpeed*Time.deltaTime);
        Destroy(gameObject, 5f);
    }
    public void Init(Vector3 dir)
    {
        _dir = dir;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy"||other.tag=="Mutant")
        {
            Destroy(gameObject);
        }
    }


}

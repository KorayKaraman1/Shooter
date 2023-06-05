using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform bulletPos;
    public Transform bulletRot;
    public GameObject bulletGo;
    public float _time;
    public AudioClip bulletSound;
    public AudioSource bulletSource;
    public bool isShot;
   
    
    public 
    
    void Start()
    {
        isShot = false;
       

        
    }

  
    void Update()
    {
        if (isShot)
        {
            isShot = false;
            StartCoroutine(Shooting(_time));
        }
    }
    public IEnumerator Shooting(float time)
    {
        while (true)
        {
            time = _time;
            GameObject bullet = Instantiate(bulletGo, bulletPos.position, Quaternion.identity);
            bullet.GetComponent<BulletController>().Init(bulletRot.position-bulletPos.position);
            bulletSource.PlayOneShot(bulletSound);
            yield return new WaitForSeconds(time);
        }
    }
}

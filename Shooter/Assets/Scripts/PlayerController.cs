using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalValue;
    public float sens;
    public Vector3 playerRot;
    public float playerHealt;
    public bool isPlayerAlive;
    public Scrollbar Scrollbar;
    public GameObject gameScreen, DeathScreen,enemySpawner;

    void Start()
    {
        isPlayerAlive = true;
        playerHealt = 1;
       
    }

   
    void Update()
    {
        PlayerRotate();
        if (playerHealt == 0)
        {
            isPlayerAlive=false;
            Time.timeScale = 0;
        }
       
        Scrollbar.size = playerHealt;
        PlayerDeath();

    }
    public void PlayerRotate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            horizontalValue = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
        playerRot=new Vector3(0,-horizontalValue,0);
        transform.Rotate(playerRot*sens*Time.deltaTime,Space.Self);

    }
    public void PlayerDeath()
    {
        if (playerHealt <= 0)
        {
            Time.timeScale = 0;
            gameScreen.SetActive(false);
            DeathScreen.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            playerHealt -= 0.2f;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Mutant")
        {
            playerHealt -= 0.4f;
            other.gameObject.SetActive(false);
        }else if (other.tag =="Tiny")
        {
            playerHealt -= 0.1f;
            other.gameObject.SetActive(false);
        }
    }
}

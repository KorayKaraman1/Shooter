using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    public GameObject player, incrementValueGO, enemyHealtGO;
    private Vector3 _dir;
    public int enemyHealt;
    public Animator animator;
    private bool _canMove;
    public TextMeshProUGUI enemyHealtText, incrementValueText;
    public CanvasController CanvasController;
    public GameObject canvas;
    public GameObject playerStats;
    public PlayerStatsController playerStatsController;
    
    
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        CanvasController=canvas.GetComponent<CanvasController>();
        playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
        playerStatsController=playerStats.GetComponent<PlayerStatsController>();
        _canMove = true;
       
    }

  
    void Update()
    {
        EnemyMovement();
        EnemyDeath();
        enemyHealtText.text=enemyHealt.ToString();
        
    }
    public void EnemyMovement()
    {
        if (_canMove==true)
        {
            Init(player.transform.position - transform.position);
            Quaternion lookPlayer = Quaternion.LookRotation(_dir);
            lookPlayer.x = 0; lookPlayer.z = 0;
            transform.rotation = lookPlayer;
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        }
 
    
    }
   
    public void Init(Vector3 dir)
    {
        _dir = dir;
    }
    public void EnemyDeath()
    {
        if (enemyHealt <= 0)
        {
            _canMove=false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            animator.SetBool("running", false);
            animator.SetBool("death", true);
            CanvasController.incrementValue = 5;
            incrementValueText.text = CanvasController.incrementValue.ToString() + "$";
            enemyHealtGO.SetActive(false);
            incrementValueGO.SetActive(true);
            Destroy(gameObject,2f);

            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bullet")
        {
            enemyHealt -= playerStatsController.bulletDamage;
        }
    }
  
    public void OnDestroy()
    {
        CanvasController.MoneyIncrease();
        CanvasController.Wave();
    }
}

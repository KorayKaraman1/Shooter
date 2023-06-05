using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsController : MonoBehaviour
{
    public int bulletDamage;
    public int damageBoostMoney, attackRateMoney, regenerationMoney;
    public CanvasController canvasController;
    public GunController gunController;
    public PlayerController playerController;
    public TextMeshProUGUI damageBoostMoneyText, attackRateMoneyText, regenerationMoneyText;
    public bool maxAttackRate,maxDamage;
    public GameObject maxDamageText, maxAttackRateText;
    void Start()
    {
        maxAttackRate = false;
        maxDamage = false;
        bulletDamage = 4;
        damageBoostMoney = 30;
        attackRateMoney = 30;
        regenerationMoney = 50;
        attackRateMoneyText.text=attackRateMoney.ToString()+"$";
        regenerationMoneyText.text=regenerationMoney.ToString()+"$";
        damageBoostMoneyText.text=damageBoostMoney.ToString()+"$";
    }

    
    void Update()
    {
        if (attackRateMoney >= 90)
        {
            maxAttackRate = true;
            attackRateMoneyText.text = null;
            maxAttackRateText.SetActive(true);
        }
        if (damageBoostMoney >=90)
        {
            maxDamage = true;
            damageBoostMoneyText.text = null;
            maxDamageText.SetActive(true);
            
        }
    }
    public void DamageButton()
    {
        if(!maxDamage) 
        {
            if (canvasController.money >= damageBoostMoney)
            {
                canvasController.money -= damageBoostMoney;
                canvasController.moneyText.text = canvasController.money.ToString() ;
                bulletDamage++;
                damageBoostMoney += 15;
                damageBoostMoneyText.text = damageBoostMoney.ToString() + "$";
            }
        }
        
    }
    public void AttackRateButton()
    {
        if (!maxAttackRate)
        {
            if (canvasController.money >= attackRateMoney)
            {
                gunController._time -= 0.4f;
                canvasController.money -= attackRateMoney;
                canvasController.moneyText.text = canvasController.money.ToString();
                attackRateMoney += 15;
                attackRateMoneyText.text = attackRateMoney.ToString() + "$";
            }
        }
        
    }
    public void RegenerationButton()
    {
        if (canvasController.money>=regenerationMoney)
        {
            playerController.playerHealt = 1;
            canvasController.money-=regenerationMoney;
            canvasController.moneyText.text = canvasController.money.ToString() ;
            regenerationMoney+= 20;
            regenerationMoneyText.text = regenerationMoney.ToString()   +"$";
        }
    }
}

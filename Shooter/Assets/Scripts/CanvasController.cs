using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GunController gunController;
    public EnemySpawnerController enemySpawnerController;
    public TextMeshProUGUI moneyText;
    public int money, incrementValue;
    public GameObject startScreen, gameScreen,deathScreen;
    public GameObject pauseButton,playButton,soundOffButton,soundOnButton;
    public Slider slider;
    public int deadEnemyValue,sliderValue;
    public AudioSource gameMusicSource;
    void Start()
    {
        sliderValue = 24;
    }

 
    void Update()
    {
       
    }
    public void MoneyIncrease()
    {
        
        money += incrementValue;
        moneyText.text = money.ToString();
        
    }
    public void StartButton()
    {
        Time.timeScale = 1;
        gameMusicSource.Play();
        gunController.isShot = true;
        enemySpawnerController.isSpawned2=true;
        startScreen.SetActive(false);
        gameScreen.SetActive(true);
    }
    public void TryAgainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PauseButton()
    {
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        Time.timeScale = 0;
        SoundOff();
    }
    public void PlayButton()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true) ;
        Time.timeScale = 1;
        SoundOn();
    }
   public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Wave()
    {
        deadEnemyValue += 1;
        slider.value += 1;
        if (slider.value >=sliderValue)
        {
            slider.value = 0;
            sliderValue = 61;
            slider.maxValue = 60;
        }
    }
    public void SoundOff()
    {
        soundOffButton.SetActive(false);
        soundOnButton.SetActive(true);
        gameMusicSource.Stop();
        gunController.bulletSource.volume = 0f;
    }
    public void SoundOn()
    {
        soundOffButton.SetActive(true);
        soundOnButton.SetActive(false);
        gameMusicSource.Play();
        gunController.bulletSource.volume = 0.2f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;
    public int howManyLives = 3;
    public TextMeshProUGUI lives;
    public Slider volumeSlider;
    private AudioSource music;
    public GameObject volumeText;
    public int objectNumbers;
    public bool isGamePaused;
    

   
    // Start is called before the first frame update
    void Start()
    {
        
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        
        
           
    }
    

    // Update is called once per frame
    void Update()
    {
        Lives();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGamePaused)
            {
                Time.timeScale = 1;
                isGamePaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isGamePaused = true;
            }
        }


    }
    public void UpdateVolume()
    {
        music.volume = volumeSlider.value;
    }
   

    public void Lives()
    {
        lives.text = "Lives:" + howManyLives;
    }
    public void Get()
    {
        howManyLives--;
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }
   public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;

    }
    public void GameOver()
    { if(howManyLives == 0)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
            lives.gameObject.SetActive(false);
        }
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        AddScore(0);
        titleScreen.gameObject.SetActive(false);
        lives.gameObject.SetActive(true);
        volumeText.gameObject.SetActive(false);
        
    }
}

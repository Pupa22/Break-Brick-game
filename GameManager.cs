using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverpanel;
    public int numberofBrick;
    public Transform[] levels;
    public int currentLevelIndex = 0;
   

    void Start()
    {
        livesText.text = "Lives : " + lives;
        scoreText.text = "score : " + score;
        numberofBrick = GameObject.FindGameObjectsWithTag("brick").Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }

    public void UpdateLives(int changInLives)
    {
        lives += changInLives;

        //Check for no lives left and trigger the end of the game
        if (lives <= 0){
            lives = 0;
            GameOver();
        }

        livesText.text = "lives : " + lives;

    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "score : " + score;
    }

    public void UpdateNumberofBrick()
    {
        numberofBrick--;
        if (numberofBrick <= 0)
        {
            if(currentLevelIndex >= levels.Length - 1)
            {
                GameOver();
            }
            else
            {
                gameOver = true;
                Invoke("LoadLevel", 3f);
            }
        }
    }

    void LoadLevel()
    {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberofBrick = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver = false;
    }

    void GameOver(){
        gameOver = true;
        gameOverpanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Scean1");
    }

    public void Quit()
    {
        Application.Quit();
        
    }
    
}


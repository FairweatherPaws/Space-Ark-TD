using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour

{
    public int score;
    public GameObject scoreText;
    private bool lossCon;
    private int lives = 5;
    // Start is called before the first frame update
    void Start()
    {
    lossCon = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerLoss()
    {
        lives--;
        if (lives < 1) { lossCon = true; }
        if (lossCon) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    }

    public void ChangeScore(int n)
    {
        score += n;
        scoreText.GetComponent<TextMesh>().text = "Score: " + score;
    }
}

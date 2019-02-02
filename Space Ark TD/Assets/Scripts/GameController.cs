using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour

{
    private bool lossCon;
    // Start is called before the first frame update
    void Start()
    {
    lossCon = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerLoss()
    {
        lossCon = true;
        if (lossCon) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    }
}

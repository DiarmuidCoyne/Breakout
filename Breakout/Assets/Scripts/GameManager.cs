using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int blocksRemaining = 0;
    public int Lives = 5;
    public string[] levels;
    public int currentLevel = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        CountBlocksInLevel();

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)) 
        {
            NextLevel();
            Debug.Log("Next");
        
        }
    }
    void CountBlocksInLevel()
    {
        blocksRemaining = GameObject.FindGameObjectsWithTag("Block").Length;

        Debug.Log($"Blocks at start {blocksRemaining}");
    }
    void GameOver()
    {
        SceneManager.LoadScene("gameover");
    }
    void GameComplete()
    {
        SceneManager.LoadScene("gamecomplete");
    }
    void NextLevel()
    {
        currentLevel++;
        
        if (currentLevel > levels.Length - 1)
        {
            GameComplete();
        }
        else
        {
            SceneManager.LoadScene(levels[currentLevel]);
            CountBlocksInLevel();
        }
    }
    public void OnBlockDestroyed()
    {
        blocksRemaining--;
        Debug.Log($"Blocks Remaining{blocksRemaining}");
        
        if(blocksRemaining <= 0)
        {
            NextLevel();
        }
        
        
    }
    public void OnBallDestroyed() 
    { 
        Lives--;
        Debug.Log($"Lives Remaining {Lives}");
        if(Lives <= 0)
        {
            GameOver();
        }

    }

}

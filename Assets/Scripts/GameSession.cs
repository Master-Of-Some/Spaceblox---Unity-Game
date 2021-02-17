using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    //config parameters
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables
    [SerializeField] int currentScore = 0;


    //Below is what's called a Singleton Pattern, (There can be only one). If anything else with same name comes along then destroy this (<GameStatus> object)
    //OTHERWISE (else DDOL method()) don't destroy it.

    //This applies to children of the game object also, (for example the canvas and therefore scoretext which we want to keep for next level). 
    //E.g Game Status object parents game canvas and so on.
  
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);        //This turns off the objects activity instantly even before destroying so that any 
            Destroy(gameObject);                //other objects calling on <GameStatus> class/object will not cause problems. (Use this whenever using singleton pattern)
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        //When we start up, our score should equal 0(currentScore)
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        //same as currentScore = currentScore + pointsPerBlockDestroyed;
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }    

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

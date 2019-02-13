using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public static GameController instance;
    public GameObject GameOver;
    public bool gameover = false;
	public float scroolSpeed = -1.4f;
    private int score = 0;
    public Text scoreText;


	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (gameover == true && (Input.GetMouseButtonDown(0)|| Input.GetKeyDown("space")))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }

   
    

    public  void BirdDie()
    {
        GameOver.SetActive(true);
        gameover = true;

    }

    public void BirdScored()
    {
        if (gameover)
        { return; }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}

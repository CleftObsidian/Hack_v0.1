using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text scoreText;
    public Text comboText;
    public Text multiScoreText;
    public bool createMode;

    private int score = 0;
    private int combo = 0;
    private int multiScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

	void Start () {
        score = 0;
        scoreText.text = "" + score;

        combo = 0;
        comboText.text = combo + " Combo";

        multiScore = 1;
        multiScoreText.text = "";
	}

    void OnTriggerEnter2D(Collider2D other)
    {
            ResetCombo();
    }

    public void AddScore()
    {
        score += 100 * multiScore;

        UIUpdate();
    }

    public void AddCombo()
    {
        combo++;

        if (combo >= 40)
        {
            multiScore = 5;
        }
        else if (combo >= 30)
        {
            multiScore = 4;
        }
        else if (combo >= 20)
        {
            multiScore = 3;
        }
        else if (combo >= 10)
        {
            multiScore = 2;
        }
        else
        {
            multiScore = 1;
        }

        UIUpdate();
    }

    public void ResetCombo()
    {
        combo = 0;

        UIUpdate();
    }

    public void UIUpdate()
    {
        scoreText.text = "" + score;
        comboText.text = combo + " Combo";

        if (multiScore > 1)
        {
            multiScoreText.text = "Score X" + multiScore;
        }
        else
        {
            multiScoreText.text = "";
        }
    }
}

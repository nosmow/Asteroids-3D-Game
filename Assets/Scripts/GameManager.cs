using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    void Update()
    {
        if (score >= 1000)
        {
            SceneManager.LoadScene("Win");
        }     
    }

    public void Score()
    {
        score += 10;
        scoreText.text = "SCORE: " + score.ToString();
    }
}

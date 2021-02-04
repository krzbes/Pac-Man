using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject deathMenu,play;
    public Text ScoreTxt;
    public InputField playerName;
    private int _points;
    public void EndGame(int points)
    {
        Time.timeScale = 0;
        play.SetActive(false);
        deathMenu.SetActive(true);
        _points = points;
        ScoreTxt.text = "Points: " + points;
        
    }
    public void SubmitEnd()
    {
        string name = playerName.text;
        Save save = new Save(name, _points);
        save.SaveScore();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu, topScores;
    public Text[] scoreTable = new Text[10];
    public void OpenGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Scores()
    {
        mainMenu.SetActive(false);
        topScores.SetActive(true);
        Save save = new Save();
        int tmp;
        for (int i = 0; i < 10; i++)
        {
             tmp = i+1;
            scoreTable[i].text = tmp+". " + save.GetScore(i);
        }
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        topScores.SetActive(false);

    }
    public void Leave()
    {
        Application.Quit();
    }
}

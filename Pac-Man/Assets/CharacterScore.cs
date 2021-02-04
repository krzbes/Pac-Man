using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterScore : MonoBehaviour
{
    public int points = 0;
    public Text ScoreTxt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            AddScore();
        }
        if (other.CompareTag("SuperPoint"))
        {
            Destroy(other.gameObject);
            AddScore(10);
            GetComponent<EnemyMenager>().ChangePhase();
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (Vector3.Distance(transform.position, other.transform.position) < 5f)
            {
                if (!GetComponent<EnemyMenager>().Phase)
                {
                    if (other.GetComponent<EnemyController>().awake)
                    {
                        AddScore(10);
                        other.GetComponent<EnemyController>().Restart();
                    }
                }
                else
                {
                    GameObject.Find("Canvas").GetComponent<UIController>().EndGame(points);
                }
            }
        }
    }
    private void AddScore()
    {
        points++;
        ScoreTxt.text = "POINTS: " + points.ToString();
    }
    public void AddScore(int value)
    {
        points+=value;
        ScoreTxt.text = "POINTS: " + points.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterScore : MonoBehaviour
{
    public int points = 0;
    public Text ScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            AddScore();
        }
    }

    void AddScore()
    {
        points++;
        ScoreTxt.text = "POINTS: " + points.ToString();
    }

}

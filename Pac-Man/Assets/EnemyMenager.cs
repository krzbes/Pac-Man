using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyMenager : MonoBehaviour
{
    public Text InfoTxt;
    public EnemyController[] enemies = new EnemyController[4];
    public float actionTime = 10f;
    private int _awaked = 0;
    private bool _phase = true;//true when enemy atack - false when he run away;
    public bool Phase
    {
        get => _phase;
    }
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            enemies[i] = GameObject.Find("Enemy " + i).GetComponent<EnemyController>();
        }
    }
    private float _timer = 0f;
    private int _phaseCounter = 0;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= actionTime)
        {
            _timer = 0f;
            if (_phase)
            {
                if (_awaked < 4)
                {
                    enemies[_awaked].WakeUp();
                    _awaked++;
                }
                else
                {
                    WakeUpSomeone();
                }
                enemies[Random.Range(0, 3)].SetTarget();
            }
            else
            {
                if (_phaseCounter == 1)
                {
                    ChangePhase();
                }
                _phaseCounter++;
            }
        }

    }
    public void ChangePhase()
    {
        if (_phase)
        {
            _phase = false;
            InfoTxt.text = "Attack";
            for (int i = 0; i < 4; i++)
            {
                
                enemies[i].RunAwayMode();
            }
        }
        else
        {
            _phaseCounter = 0;
            _phase = true;
            InfoTxt.text = "Escape";
            for (int i = 0; i < 4; i++)
            {
                enemies[i].AttackMode();
            }
        }
    } 
    public void WakeUpSomeone()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!enemies[i].awake)
            {
                enemies[i].WakeUp();
                return;
            }
        }
    }
}
    

    
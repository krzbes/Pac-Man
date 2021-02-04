using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private bool _onPlayer;
    public bool scared=false,awake=false;
    private Vector3[] _corners ={ new Vector3(124f, 4f, -175f), new Vector3(125f, 4f, 175f), new Vector3(-114f, 4f, 175f), new Vector3(-124f, 4f - 175f) };
    private Vector3 _startPoint;
    public bool OnPlayer 
    {
        get => _onPlayer;
    }
    public Transform target;
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _startPoint = transform.position;
    }
    public void RunAwayMode()
    {
        scared = true;
    }
    public void AttackMode()
    {
        scared = false;
    }
    public void Restart()
    {
        transform.position = _startPoint;
        _agent.destination = _startPoint;
        awake = false;
    }
    public void WakeUp()
    {
        awake = true;
        _agent.destination = target.position;
    }
    public void SetTarget()
    {
        if (awake && !_onPlayer)
        {
            _agent.destination = target.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            if (awake && !scared)
            {
                if (!_onPlayer)
                {
                    _onPlayer = true;
                }
                _agent.destination = other.transform.position;
            }
            if (awake && scared)
            {
                _agent.destination = CalculateCorner();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _onPlayer = false;
        }
    }
    private Vector3 CalculateCorner()
    {
        Vector3 solution =  Vector3.zero;
        float difference = 0;
        foreach (Vector3 corner in _corners)
        {
            float tmp = Vector3.Distance(target.position, corner);
            if(difference < tmp)
            {
                difference = tmp;
                solution = corner;
            }
        }
        return solution;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("General Attributes")]
    [SerializeField] private Rigidbody2D m_RigidBody;
    [SerializeField] private float m_FrontalChecker = 3f;
    [SerializeField] private ObjectiveTracker m_Tracker;
    [SerializeField] private Transform m_PlayerTargetDirection;

    [Header("Movement Controllers")]
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private LayerMask m_WallLayer;
    private Transform _CurrentTarget;
    private Vector2 _MoveNextPosition;
    private Vector2[] _PossiblePositions = new Vector2[8];

    private bool _Play = false;

    private void Start()
    {
        Play();
    }

    private void Update()
    {
        UpdatePositions();
        TimeScale();
        GetObjective();
        GetNextMovePosition();
        Move();
    }

    public void UpdatePositions()
    {
        _PossiblePositions[0] = (Vector2)transform.position + ((Vector2.up) * m_FrontalChecker);
        _PossiblePositions[1] = (Vector2)transform.position + ((Vector2.up + Vector2.right).normalized * m_FrontalChecker);
        _PossiblePositions[2] = (Vector2)transform.position + ((Vector2.right) * m_FrontalChecker);
        _PossiblePositions[3] = (Vector2)transform.position + ((Vector2.right + Vector2.down).normalized * m_FrontalChecker);
        _PossiblePositions[4] = (Vector2)transform.position + ((Vector2.down) * m_FrontalChecker);
        _PossiblePositions[5] = (Vector2)transform.position + ((Vector2.down + Vector2.left).normalized * m_FrontalChecker);
        _PossiblePositions[6] = (Vector2)transform.position + ((Vector2.left) * m_FrontalChecker);
        _PossiblePositions[7] = (Vector2)transform.position + ((Vector2.left + Vector2.up).normalized * m_FrontalChecker);
    }

    public void GetObjective()
    {
        _CurrentTarget = m_Tracker.NearbyObjective();
        //Debug.Log("My Nearby Objective is: " + _CurrentTarget.name);
    }

    public void GetNextMovePosition()
    {
        m_PlayerTargetDirection.transform.position = transform.position;

        RaycastHit2D[] hit = new RaycastHit2D[_PossiblePositions.Length - 1];

        for (int i = 0; i < _PossiblePositions.Length; i++)
        {
            hit[i] = Physics2D.Raycast(transform.position, _PossiblePositions[i], m_FrontalChecker);
        }

        if(hit[NearbyHitIndex(hit)].collider.CompareTag("Wall"))


        _MoveNextPosition = NearbyPosition();
    }

    public int NearbyHitIndex(RaycastHit2D[] hits)
    {
        int nearbyIndex = 0;
        int[] nearbyList = new int[hits.Length];

        for (int i = 0; i < nearbyList.Length; i++)
        {
            nearbyList[i] = i;
        }

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == hits[nearbyIndex])
                continue;

            if (Vector2.Distance(_CurrentTarget.transform.position, hits[i].point) < Vector2.Distance(_CurrentTarget.transform.position, hits[nearbyIndex].point))
            {
                //for (int j = 0; j < nearbyList.Length; j++)
                //{

                //}
            }
        }

        return nearbyIndex;
    }

    public Vector2 NearbyPosition()
    {
        int nearbyIndex = 0;

        for (int i = 0; i < _PossiblePositions.Length; i++)
        {
            if (_PossiblePositions[i] == _PossiblePositions[nearbyIndex])
                continue;

            if (Vector2.Distance(transform.position, _PossiblePositions[i]) < Vector2.Distance(transform.position, _PossiblePositions[nearbyIndex]))
                nearbyIndex = i;
        }

        return _PossiblePositions[nearbyIndex];
    }

    public Vector2 NearbyRayCast(RaycastHit2D[] hits)
    {
        int nearbyIndex = 0;

        for (int i = 0; i < _PossiblePositions.Length; i++)
        {
            if (_PossiblePositions[i] == _PossiblePositions[nearbyIndex])
                continue;

            if (Vector2.Distance(transform.position, _PossiblePositions[i]) < Vector2.Distance(transform.position, _PossiblePositions[nearbyIndex]))
                nearbyIndex = i;
        }

        return _PossiblePositions[nearbyIndex];
    }

    [ContextMenu("Play")]
    public void Play() => _Play = true;
    [ContextMenu("Stop")]
    public void Stop() => _Play = false;
    public void Move() => m_RigidBody.velocity = _MoveNextPosition * m_MoveSpeed;

    public void TimeScale() => Time.timeScale = _Play ? 1 : 0;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _PossiblePositions[0]);
        Gizmos.DrawLine(transform.position, _PossiblePositions[1]);
        Gizmos.DrawLine(transform.position, _PossiblePositions[2]);
        Gizmos.DrawLine(transform.position, _PossiblePositions[3]);
        Gizmos.DrawLine(transform.position, _PossiblePositions[4]);
        Gizmos.DrawLine(transform.position, _PossiblePositions[5]);
        Gizmos.DrawLine(transform.position, _PossiblePositions[6]);
        Gizmos.DrawLine(transform.position, _PossiblePositions[7]);
    }
}

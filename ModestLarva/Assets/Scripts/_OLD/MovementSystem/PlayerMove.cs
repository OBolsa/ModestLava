using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Behaviour
{
    Fight,
    Run
}

public class PlayerMove : MonoBehaviour
{
    [Header("General Attributes")]
    [SerializeField] private Rigidbody2D m_RigidBody;
    [SerializeField] private float m_FrontalChecker = 3f;
    [SerializeField] private ObjectiveTracker m_Tracker;
    [SerializeField] private PointsTracker m_Points;
    [SerializeField] private Transform m_PlayerTargetDirection;
    [SerializeField] private CreatureStrenght m_CreatureStrenght;

    [Header("Movement Controllers")]
    [SerializeField] private Behaviour m_PlayerBehaviour;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private LayerMask m_WallLayer;
    private Objective _CurrentObjective;
    private Transform _CurrentTarget;
    private Vector2 _MoveDirection;

    public Transform CurrentTarget => _CurrentTarget;

    private bool _Play = false;

    private void Awake()
    {
        Stop();
    }

    private void Start()
    {
        GetObjective();
        Play();
    }

    private void Update()
    {
        GetObjective();
        TimeScale();

        if(m_PlayerBehaviour == Behaviour.Fight)
            GetFightNextMovePosition();
        if(m_PlayerBehaviour == Behaviour.Run)

        Move();
    }

    public void GetObjective()
    {
        _CurrentTarget = m_Tracker.NearbyObjectiveTransform();
        _CurrentObjective = m_Tracker.NearbyObjective();

        switch (_CurrentObjective.Type)
        {
            default:
            case ObjectiveType.Enemy:
                m_PlayerBehaviour = _CurrentObjective.GetComponent<CreatureStrenght>().Strenght > m_CreatureStrenght.Strenght ? Behaviour.Run : Behaviour.Fight;
                break;
            case ObjectiveType.Scene:
            case ObjectiveType.Buff:
                m_PlayerBehaviour = Behaviour.Fight;
                break;
        }
    }

    public void GetFightNextMovePosition()
    {
        _MoveDirection = m_Points.NearbyPoint.position - transform.position;
    }

    public void GetRunNextMovePosition()
    {
        _MoveDirection = m_Points.NearbyPoint.position - transform.position;
    }

    [ContextMenu("Play")]
    public void Play() => _Play = true;
    [ContextMenu("Stop")]
    public void Stop() => _Play = false;
    public void Move() => m_RigidBody.velocity = _MoveDirection.normalized * m_MoveSpeed;
    public void TimeScale() => Time.timeScale = _Play ? 1 : 0;

}
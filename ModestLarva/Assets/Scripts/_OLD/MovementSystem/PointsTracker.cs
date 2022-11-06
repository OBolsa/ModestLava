using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsTracker : MonoBehaviour
{
    [SerializeField] private List<MovePoint> m_Points = new List<MovePoint>();
    [SerializeField] private ActionChannel m_Channel;
    [SerializeField] private ObjectiveTracker m_Tracker;
    [SerializeField] private Transform _NearbyPoint;
    [SerializeField] private Transform _FarPoint;
    [SerializeField] private float m_DotProductThreshold = 0.5f;
    private Transform _PreviousNearbyPoint;
    public Transform NearbyPoint => _NearbyPoint;
    public Transform FarPoint => _FarPoint;
    private float callingTime;

    private void Start()
    {
        UpdatePoints();
    }

    private void Update()
    {
        callingTime += Time.deltaTime;

        if(callingTime > 0.25f)
        {
            UpdatePoints();
            callingTime = 0;
        }
    }

    public void UpdatePoints()
    {
        foreach (MovePoint point in m_Points)
        {
            point.gameObject.SetActive(true);
        }

        foreach (MovePoint point in m_Points)
        {
            point.CheckBoundaries();

            if(!point.ActivePoint)
                point.gameObject.SetActive(false);
        }

        _PreviousNearbyPoint = _NearbyPoint;
        _NearbyPoint = GetNearbyPoint();
        _FarPoint = GetFarPoint();
    }

    public Transform GetNearbyPoint()
    {
        int nearbyIndex = 0;

        for (int i = 0; i < m_Points.Count; i++)
        {
            if (!m_Points[i].gameObject.activeSelf)
            {
                if (nearbyIndex == i)
                    nearbyIndex += 1;
                continue;
            }

            if (Vector2.Distance(m_Tracker.NearbyObjectiveTransform().position, m_Points[i].transform.position) < Vector2.Distance(m_Tracker.NearbyObjectiveTransform().position, m_Points[nearbyIndex].transform.position))
            {
                Vector2 previousDirection = _PreviousNearbyPoint.position - transform.position;
                Vector2 newDirection = m_Points[i].transform.position - transform.position;

                if (Vector2.Dot(newDirection.normalized, previousDirection.normalized) < m_DotProductThreshold)
                    continue;

                nearbyIndex = i;
            }
        }

        return m_Points[nearbyIndex].transform;
    }

    public Transform GetFarPoint()
    {
        int nearbyIndex = 0;

        for (int i = 0; i < m_Points.Count; i++)
        {
            if (!m_Points[i].gameObject.activeSelf)
            {
                if (nearbyIndex == i)
                    nearbyIndex += 1;
                continue;
            }

            if (Vector2.Distance(m_Tracker.NearbyObjectiveTransform().position, m_Points[i].transform.position) > Vector2.Distance(m_Tracker.NearbyObjectiveTransform().position, m_Points[nearbyIndex].transform.position))
            {
                Vector2 previousDirection = _PreviousNearbyPoint.position - transform.position;
                Vector2 newDirection = m_Points[i].transform.position - transform.position;

                if (Vector2.Dot(newDirection.normalized, previousDirection.normalized) < m_DotProductThreshold)
                    continue;

                nearbyIndex = i;
            }
        }

        return m_Points[nearbyIndex].transform;
    }
}
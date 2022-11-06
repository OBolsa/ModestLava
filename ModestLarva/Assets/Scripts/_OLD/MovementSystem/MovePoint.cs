using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField] private string m_PointDirection;
    [SerializeField] private ActionChannel m_ActionChannel;
    [SerializeField] private LayerMask m_Walls;
    private bool _ActivePoint = true;
    public string PointDirection => m_PointDirection;
    public bool ActivePoint => _ActivePoint;

    public void CheckBoundaries()
    {
        _ActivePoint = !Physics2D.OverlapCircle(transform.position, 0.5f, m_Walls);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _ActivePoint ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
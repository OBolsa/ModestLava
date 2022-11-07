using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSpot : MonoBehaviour
{
    [SerializeField] private int ID;
    [SerializeField] private GameObject m_Target;
    [SerializeField] private TeleportChannel m_Channel;

    private void Awake()
    {
        m_Channel.OnTeleport += DoTeleport;
    }

    private void OnDestroy()
    {
        m_Channel.OnTeleport -= DoTeleport;
    }

    public void DoTeleport(int id)
    {
        if (id != ID)
            return;

        m_Target.transform.position = transform.position;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Teleport")]
public class TeleportChannel : ScriptableObject
{
    public delegate void TeleportCallback(int id);
    public TeleportCallback OnTeleport;

    public void RaiseTeleport(int id)
    {
        OnTeleport?.Invoke(id);
    }
}

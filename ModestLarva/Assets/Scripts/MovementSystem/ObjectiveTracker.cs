using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    private List<Objective> _Objective = new List<Objective>();

    private void Start()
    {
        FillObjectives();
    }

    public void FillObjectives()
    {
        Objective[] objectivesInScene = FindObjectsOfType<Objective>();

        foreach (Objective objective in objectivesInScene)
        {
            _Objective.Add(objective);
        }
    }

    public Transform NearbyObjective()
    {
        int nearbyIndex = 0;

        for(int i = 0; i < _Objective.Count; i++)
        {
            if (_Objective[i] == _Objective[nearbyIndex])
                continue;

            if (Vector2.Distance(transform.position, _Objective[i].transform.position) < Vector2.Distance(transform.position, _Objective[nearbyIndex].transform.position))
                nearbyIndex = i;
        }

        return _Objective[nearbyIndex].transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionInstigator : MonoBehaviour
{
    public List<Interaction> m_Interactions = new List<Interaction>();
    private Interaction _Interaction;

    private void Update()
    {
        if (HasNearbyInteractables() && Input.GetButtonDown("Submit"))
        {
            ClosestInteractables().DoInteraction();
        }
        else if (GetComponentInParent<CharacterController>().CharacterName == "Karl")
        {

        }
    }

    public bool HasNearbyInteractables()
    {
        return m_Interactions.Count != 0;
    }

    public Interaction ClosestInteractables()
    {
        int closestIndex = 0;

        for (int i = 0; i < m_Interactions.Count; i++)
        {
            var atualClosest = Vector3.Distance(m_Interactions[closestIndex].transform.position, transform.position);
            var newCheackage = Vector3.Distance(m_Interactions[i].transform.position, transform.position);

            if (newCheackage < atualClosest)
            {
                closestIndex = i;
            }
        }

        return m_Interactions[closestIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interaction interaction = collision.GetComponent<Interaction>();

        if(interaction != null)
        {
            if(interaction != _Interaction)
                m_Interactions.Add(interaction);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Interaction interaction = collision.GetComponent<Interaction>();

        if(interaction != null)
        {
            if (interaction != _Interaction)
                m_Interactions.Remove(interaction);
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveByClicking : MonoBehaviour
{
    public event Action<GameObject> OnAgentSelected;
    [SerializeField] private NavMeshAgent agent;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    agent = hit.collider.gameObject.GetComponent<NavMeshAgent>();
                    OnAgentSelected?.Invoke(hit.collider.gameObject);
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            MoveToClick();
        }
    }

    private void MoveToClick()
    {
        if(agent != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}

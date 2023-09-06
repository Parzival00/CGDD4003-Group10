using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public enum Mode
    {
        Dormant,
        Chase,
        Scatter,
        Respawn
    }

    protected Mode currentMode;

    [SerializeField] protected NavMeshAgent navMesh;
    [SerializeField] protected Map map;
    [SerializeField] protected int pelletsNeededToStart = 10;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected Transform player;

    protected Vector3 targetPosition;
    protected Vector2Int lastPlayerGridPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentMode = Mode.Dormant;

        if (navMesh == null)
            navMesh = GetComponent<NavMeshAgent>();

        navMesh.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Act();
    }

    public void Act()
    {
        switch(currentMode)
        {
            case Mode.Chase:
                Chase();
                break;
            case Mode.Scatter:
                Scatter();
                break;
            case Mode.Dormant:
                Dormant();
                break;
            case Mode.Respawn:
                Respawn();
                break;
        }
    }

    protected virtual void Chase()
    {
        Vector2Int playerGridPosition = map.GetPlayerPosition();

        if(lastPlayerGridPosition != playerGridPosition)
        {
            targetPosition = map.GetWorldFromGrid(playerGridPosition);

            navMesh.SetDestination(targetPosition);
        }

        lastPlayerGridPosition = playerGridPosition;
    }

    protected virtual void Scatter()
    {

    }

    protected virtual void Dormant()
    {
        currentMode = Mode.Chase;
    }

    protected virtual void Respawn()
    {

    }
}

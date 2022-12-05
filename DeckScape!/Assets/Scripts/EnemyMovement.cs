using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 10f;


    private int currentPathIndex;
    private List<Vector3> pathVectorList;

    private GameObject manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        Transform bodyTransform = transform.Find("Enemy");
    }

    private void Update()
    {
        HandleMovement();
        Vector3 PlayerPos = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, GameObject.Find("Player").transform.position.z);

        if (/*Input.GetMouseButtonDown(0) && */manager.GetComponent<TurnManager>().GetTurn() == true)
        {
            SetTargetPosition(PlayerPos);
            manager.GetComponent<TurnManager>().SetTurn(false);
        }
    }

    private void HandleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                
                Vector3 moveDir = (targetPosition - transform.position).normalized;
                Vector3 kierunek = moveDir;
                if (moveDir.x !=0 && moveDir.y !=0)
                {
                    if (moveDir.x > 0 && moveDir.y > 0)
                    {
                        Vector3 pos = transform.position;
                        pos.x = pos.x + 1;
                        pos.y = pos.y + 1;
                        transform.position = pos;
                    }
                    if (moveDir.x > 0 && moveDir.y < 0)
                    {
                        Vector3 pos = transform.position;
                        pos.x = pos.x + 1;
                        pos.y = pos.y - 1;
                        transform.position = pos;
                    }
                    if (moveDir.x < 0 && moveDir.y > 0)
                    {
                        Vector3 pos = transform.position;
                        pos.x = pos.x - 1;
                        pos.y = pos.y + 1;
                        transform.position = pos;
                    }
                    if (moveDir.x < 0 && moveDir.y < 0)
                    {
                        Vector3 pos = transform.position;
                        pos.x = pos.x - 1;
                        pos.y = pos.y - 1;
                        transform.position = pos;
                    }
                    Debug.Log("Skos!" + kierunek);
                }
                else
                {
                    if (moveDir.x > 0)
                    {
                        Vector3 pos = transform.position;
                        pos.x = pos.x + 1;
                        transform.position = pos;
                    }
                    if (moveDir.x < 0)
                    {
                        Vector3 pos = transform.position;
                        pos.x = pos.x - 1;
                        transform.position = pos;
                    }
                    if (moveDir.y > 0)
                    {
                        Vector3 pos = transform.position;
                        pos.y = pos.y + 1;
                        transform.position = pos;
                    }
                    if (moveDir.y < 0)
                    {
                        Vector3 pos = transform.position;
                        pos.y = pos.y - 1;
                        transform.position = pos;
                    }
                    Debug.Log("Prosto!" + kierunek);
                }
                
                float distanceBefore = Vector3.Distance(transform.position, targetPosition);


                //transform.position = transform.position + kierunek.normalized * speed * Time.deltaTime;
                //transform.position = transform.position + moveDir * speed * Time.deltaTime;


                StopMoving();
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                }
            }
        }
    }

    private void StopMoving()
    {
        pathVectorList = null;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }

}
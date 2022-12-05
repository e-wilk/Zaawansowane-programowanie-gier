
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Testing : MonoBehaviour
{
    [SerializeField] private PathfindingVisual pathfindingVisual;
    [SerializeField] private EnemyMovement EnemyMovement;
    private Pathfinding pathfinding;

    public GameObject PlayerTurn;

    private GameObject manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");


        pathfinding = new Pathfinding(19, 11);
        //pathfindingVisual.SetGrid(pathfinding.GetGrid());
        pathfinding.GetNode(4, 2).SetIsWalkable(!pathfinding.GetNode(4, 2).isWalkable);
        pathfinding.GetNode(3, 7).SetIsWalkable(!pathfinding.GetNode(3, 7).isWalkable);
        pathfinding.GetNode(10, 8).SetIsWalkable(!pathfinding.GetNode(10, 8).isWalkable);
        pathfinding.GetNode(12, 5).SetIsWalkable(!pathfinding.GetNode(12, 5).isWalkable);
        pathfinding.GetNode(16, 4).SetIsWalkable(!pathfinding.GetNode(16, 4).isWalkable);

        pathfinding.GetNode(9, 3).SetIsWalkable(!pathfinding.GetNode(9, 3).isWalkable);
        pathfinding.GetNode(10, 3).SetIsWalkable(!pathfinding.GetNode(10, 3).isWalkable);
        pathfinding.GetNode(11, 3).SetIsWalkable(!pathfinding.GetNode(11, 3).isWalkable);
        pathfinding.GetNode(9, 4).SetIsWalkable(!pathfinding.GetNode(9, 4).isWalkable);
        pathfinding.GetNode(10, 4).SetIsWalkable(!pathfinding.GetNode(10, 4).isWalkable);
        pathfinding.GetNode(11, 4).SetIsWalkable(!pathfinding.GetNode(11, 4).isWalkable);

        pathfinding.GetNode(13, 9).SetIsWalkable(!pathfinding.GetNode(13, 9).isWalkable);
        pathfinding.GetNode(17, 9).SetIsWalkable(!pathfinding.GetNode(17, 9).isWalkable);

    }

    public void Update()
    {
        float playerXPos = GameObject.Find("Player").transform.position.x;
        float playerYPos = GameObject.Find("Player").transform.position.y;
        float playerZPos = GameObject.Find("Player").transform.position.z;

        float enemyXPos = GameObject.Find("Enemy").transform.position.x;
        float enemyYPos = GameObject.Find("Enemy").transform.position.y;

        Vector3 PlayerPos = new Vector3(playerXPos, playerYPos, playerZPos);


            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
                pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
                List<PathNode> path = pathfinding.FindPath((int)enemyXPos, (int)enemyYPos, (int)playerXPos, (int)playerYPos);
                //List<PathNode> path = pathfinding.FindPath(2, 2, (int)playerXPos, (int)playerYPos);
                if (path != null)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 1f + Vector3.one * .5f, new Vector3(path[i + 1].x, path[i + 1].y) * 1f + Vector3.one * .5f, Color.green, 1f);
                    }
                };
            //manager.GetComponent<TurnManager>().SetTurn(false);
            }
    }

}

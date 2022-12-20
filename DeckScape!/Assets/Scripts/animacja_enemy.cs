using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacja_enemy : MonoBehaviour
{
    private Animator anim;
    private bool move;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        move = GameObject.Find("Enemy").GetComponent<EnemyMovement>().movement;
        if (move == false)
        {
            anim.SetBool("enemy_moving", false);
        }
        else
        {
            anim.SetBool("enemy_moving", true);
        }
    }
}

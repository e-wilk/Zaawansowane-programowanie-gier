using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private bool turn; //false - player, true- ai
    // Start is called before the first frame update
    void Start()
    {
        turn = false;
        Debug.Log("turn is " + turn);
    }

    public void SetTurn(bool t)
    {
        turn = t;
        Debug.Log("turn is " + turn);
    }

    public bool GetTurn()
    {
        return turn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

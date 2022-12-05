using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 2f;
    public Transform movePoint; //miejsce do ktorego chcemy przeniesc nasza postac

    public LayerMask whatStopsMovement;

    public bool playerTurn = true;

    private GameObject manager;
    private GameObject karta_obj;
    private GameObject karta9_obj;

    public bool Karta2;
    public bool Karta9;

    void Start()
    {
        movePoint.parent = null; //na poczatku ustawiamy, zeby w.w miejsce nie było dzieckiem postaci, bo wtedy byłoby bezposrednio powiazane z miejscem w ktorym nasza postac sie znajduje
        manager = GameObject.FindGameObjectWithTag("Manager");
        karta_obj = GameObject.FindGameObjectWithTag("Karta2");
        karta9_obj = GameObject.FindGameObjectWithTag("Karta9");

        Karta2 = false;
        Karta9 = false;
    }


    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    public void playerMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime); // ikona gracza przesuwa sie w miejsce do ktorego chcemy (movePoint)

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.5f && manager.GetComponent<TurnManager>().GetTurn() == false) // sprawia to, ze gracz wykonuje '1 krok na raz', bez tego nasza postac po wcisnieciu klawisza ruchu bez przerwy sunelaby sie w jednym kierunku
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) // poruszanie sie w kierunkach lewo / prawo
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement)) // sprawdzenie czy przed graczem jest przeszkoda, przez ktora nie moze przejsc
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    
                    if (Karta2 == true)
                    {
                        setKarta2();
                        karta_obj.GetComponent<Karta2>().znacznikFalse();
                    }
                    //else
                      //  manager.GetComponent<TurnManager>().SetTurn(true);
                    
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) // poruszanie sie w kierunkach gora/dol / else if dlatego, zeby gracz nie mogl poruszac sie na skos, jezeli chcemy dac ta mozliwosc, zamiase else if trzeba wstawic kolejnego if'a
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement)) // -||-
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

                    if (Karta2 == true)
                    {
                        setKarta2();
                        karta_obj.GetComponent<Karta2>().znacznikFalse();
                    }
                  //  else
                      //  manager.GetComponent<TurnManager>().SetTurn(true);
                }
            }

            else if (Input.GetKeyDown("[1]") && Karta9 == true)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, -1f, 0f), .2f, whatStopsMovement)) // -||-
                {
                    manager.GetComponent<TurnManager>().SetTurn(true);
                    movePoint.position += new Vector3(-1f, -1f, 0f);
                    setKarta9();
                    karta9_obj.GetComponent<Karta9>().znacznikFalse();
                }
            }
            else if (Input.GetKeyDown("[3]") && Karta9 == true)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, -1f, 0f), .2f, whatStopsMovement)) // -||-
                {
                    manager.GetComponent<TurnManager>().SetTurn(true);
                    movePoint.position += new Vector3(1f, -1f, 0f);
                    setKarta9();
                    karta9_obj.GetComponent<Karta9>().znacznikFalse();
                }
            }
            else if (Input.GetKeyDown("[7]") && Karta9 == true)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 1f, 0f), .2f, whatStopsMovement)) // -||-
                {
                    manager.GetComponent<TurnManager>().SetTurn(true);
                    movePoint.position += new Vector3(-1f, 1f, 0f);
                    setKarta9();
                    karta9_obj.GetComponent<Karta9>().znacznikFalse();
                }
            }
            else if (Input.GetKeyDown("[9]") && Karta9 == true)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 1f, 0f), .2f, whatStopsMovement)) // -||-
                {
                    manager.GetComponent<TurnManager>().SetTurn(true);
                    movePoint.position += new Vector3(1f, 1f, 0f);
                    setKarta9();
                    karta9_obj.GetComponent<Karta9>().znacznikFalse();
                }
            }
        }
    }
    public void setKarta2()
    {
        Karta2 = !Karta2;
    }

    public void setKarta9()
    {
        Karta9 = !Karta9;
    }
}

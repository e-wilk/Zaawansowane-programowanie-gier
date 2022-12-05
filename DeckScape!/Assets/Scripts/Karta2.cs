using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karta2 : MonoBehaviour
{
    private GameObject player;
    public GameObject znacznik;
    
    private bool czyZebrane = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        znacznik = GameObject.FindGameObjectWithTag("Znacznik2");

        znacznik.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && czyZebrane == false)
        {
            znacznikTrue();

            player.GetComponent<PlayerController>().setKarta2();
            gameObject.SetActive(false);
            czyZebrane = true;
        }
    }
    public void znacznikTrue()
    {
        znacznik.SetActive(true);
    }
    public void znacznikFalse()
    {
        znacznik.SetActive(false);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{

    public GameObject horse;
    public float velocidadHorse;
    public float amplitudHorse;

    public float numAvancePlayer1;
    public float numRetrocesoPlayer2;

    private Vector3 posicionInicialHorse;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicialHorse = horse.transform.position;
    }

    // Update is called once per frame
    void Update()
	{
        horse.transform.position += new Vector3(0, Mathf.Sin(Time.time) * velocidadHorse * amplitudHorse, 0);

        if (InputManager.GetActionDown(Player.One)) {
            horse.transform.position += new Vector3(numAvancePlayer1, 0, 0);
        }

        if (InputManager.GetActionDown(Player.Two) && horse.transform.position.x >= posicionInicialHorse.x)
        {
            horse.transform.position -= new Vector3(numRetrocesoPlayer2, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            //ACTIVAR TRANSICION CAMBIO NIVEL
        }
    }
}

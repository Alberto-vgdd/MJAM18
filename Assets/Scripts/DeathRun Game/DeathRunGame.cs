using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRunGame : MonoBehaviour
{
    public GameObject ballPlayer1;
    public Animator cuchillosPlayer2;
    public float speedBall;
    public float speedCuchillos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO PELOTA PLAYER 1
        ballPlayer1.GetComponent<Rigidbody>().velocity = new Vector3(InputManager.GetHorizontalAxis(Player.One) * speedBall, 0, 0);

        //MOVIMIENTO CUCHILLO PLAYER 2
        if(InputManager.GetActionDown(Player.Two)) {
            cuchillosPlayer2.SetTrigger("cuchillos");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fin")
        {
            //TRANSICION GANA EL HEROE
        }

        if (other.tag == "Muerte")
        {
            //TRANSICION ESPAÑOLA GANA EL VILLANO
        }
    }
}

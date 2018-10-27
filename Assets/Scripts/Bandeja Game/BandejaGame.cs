using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandejaGame : MonoBehaviour
{
    public GameObject ballPlayer1;
    public GameObject badejaPlayer2;
    public float speedBall;
    public float speedBandeja;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MOVIMIENTO PELOTA PLAYER 1
        ballPlayer1.GetComponent<Rigidbody>().velocity = new Vector3(InputManager.GetHorizontalAxis(Player.One) * speedBall, ballPlayer1.GetComponent<Rigidbody>().velocity.y, InputManager.GetVerticalAxis(Player.One) * speedBall);

        //MOVIMIENTO BANDEJA PLAYER 2
        badejaPlayer2.transform.rotation *= Quaternion.Euler(0, 0, -InputManager.GetHorizontalAxis(Player.Two) * speedBandeja * Time.fixedDeltaTime);
        /*
        if (badejaPlayer2.transform.rotation.z <= 0.40 && badejaPlayer2.transform.rotation.z >= -0.40)
        {
            badejaPlayer2.transform.rotation *= Quaternion.Euler(0, 0, -InputManager.GetHorizontalAxis(Player.Two) * speedBandeja * Time.fixedDeltaTime);
        }
        else if (badejaPlayer2.transform.rotation.z >= 0.40 && InputManager.GetHorizontalAxis(Player.Two) > 0)
        {
            badejaPlayer2.transform.rotation *= Quaternion.Euler(0, 0, -InputManager.GetHorizontalAxis(Player.One) * speedBandeja * Time.fixedDeltaTime);
        }

        else if (badejaPlayer2.transform.rotation.z <= -0.40 && InputManager.GetHorizontalAxis(Player.Two) < 0)
        {
            badejaPlayer2.transform.rotation *= Quaternion.Euler(0, 0, -InputManager.GetHorizontalAxis(Player.One) * speedBandeja * Time.fixedDeltaTime);
        }
        */
    }

}

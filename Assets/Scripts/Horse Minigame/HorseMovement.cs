using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{

    public GameObject horse;
    public float velocidadHorse;
    public float amplitudHorse;

    public float numAvancePlayer1;
    public float numRetrocesoPlayer2;
    public bool action0;
    public bool action1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
	{
        action0 = InputManager.GetAction(Player.One);
        action1 = InputManager.GetAction(Player.Two);
        //horse.transform.position += new Vector3(0, Mathf.Sin(Time.time) * velocidadHorse * amplitudHorse, 0);

        if (action0) {
            horse.transform.position += new Vector3(numAvancePlayer1, 0, 0);
        }

        if (action1)
        {
            horse.transform.position -= new Vector3(numRetrocesoPlayer2, 0, 0);
        }
    }
}

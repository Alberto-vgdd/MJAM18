using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {

	Vector3 posicion;
	public float amplitud, velocidad;

	// Use this for initialization
	void Start () {
		posicion = this.transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		posicion.y = posicion.y + Mathf.Sin(Time.time) * velocidad * amplitud;
		this.transform.position = posicion;
	}
}

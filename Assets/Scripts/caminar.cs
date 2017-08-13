using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminar : MonoBehaviour {

	//Variables
	public float velocidad = 6.0F;
	public float velocidadSalto = 8.0F; 
	public float gravedad = 20.0F;
	private Vector3 direccion = Vector3.zero;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		// el personaje esta en el suelo?
		if (controller.isGrounded) {
			//Traer los valores del teclado
			direccion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			direccion = transform.TransformDirection(direccion);
			//Multiplicar por velocidad.
			direccion *= velocidad;
			//Saltar
			if (Input.GetButton("Jump"))
				direccion.y = velocidadSalto;
			
		}
		//Aplicar gravedad
		direccion.y -= gravedad * Time.deltaTime;
		//Mover al mono
		controller.Move(direccion * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidBody : MonoBehaviour
{
    public float pushPower = 2.0f;
	private float targetMass; 
	//cuando chocamos con un objeto
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody; //alamazenar el rigidbody que chocamos

		if (body == null || body.isKinematic) //Sino hay rigidbody o que no este afectado por las fisicas, que no haga nada 
		{
			return;
		}
		//si lo empujamos hacia abajo, no haga nada
		if (hit.moveDirection.y <-0.3) 
		{
			return; 
		}

		targetMass = body.mass; 
		//direción donde estamos golpeando
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		//caja se mueva
		body.velocity = pushDir * pushPower / targetMass; 
	}
}

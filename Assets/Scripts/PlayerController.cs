using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;

    private Vector3 playerInput; 
    public CharacterController player;

    public float playerSpeed;
    private Vector3 movPlayer; //Donde se tiene que mover el player respecto la camera
    public float gravity = 9.8f;
    public float failveolocity;
    public float jumpForce;
    //Camera
    public Camera mainCamera;
    private Vector3 camForward; //Donde esta mirando la camera
    private Vector3 camRight; //direction of Camera
    //pendiente bajar
    public bool isOnSlope = false; //si estamos en la rampa
    private Vector3 hitNormal;
    public float slideVelocity; //velocidad de desplazamiento
    public float slopeForceDown; 

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        // Para que el movimiento vaya de 0-1
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput,1);

        //Mover player respecto la camera
        camDirection();
        //rectificar la posicion del player para que siempre mire a la camera
        movPlayer = playerInput.x * camRight + playerInput.z * camForward;

        movPlayer = movPlayer * playerSpeed; 

        player.transform.LookAt(player.transform.position + movPlayer);
        //Gravity
        SetGravity();
        //Función para las habilidades de nuestro jugador. 
        PlayerSkills();
        //Move Player
        player.Move(movPlayer * Time.deltaTime);

    }

    public void camDirection() 
    {
        camForward = mainCamera.transform.forward; //direción de delante
        camRight = mainCamera.transform.right; //direction right of camera

        camRight.y = 0;
        camForward.y = 0;

        //valores normalizados, 0-1
        camForward = camForward.normalized;
        camRight = camRight.normalized; 
    }

    public void SetGravity() 
    {
        if (player.isGrounded)
        {
            failveolocity = -gravity * Time.deltaTime;
            movPlayer.y = failveolocity; 
        }
        else {
            failveolocity -= gravity * Time.deltaTime;
            movPlayer.y = failveolocity;
        }
        SlideDown();
    }
    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump")) //JUMP
        {
            failveolocity = jumpForce;
            movPlayer.y = failveolocity;
        }
    }
    //si esta en una rampa muy empinada
    public void SlideDown()
    {//es verdadero si el angulo del player es mayor al angulo minimo que puede subirse
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;
        if (isOnSlope)//is true
        {   //que varie la fuerza segun la pendiente de la rampa
            movPlayer.x += ((1f-hitNormal.y) * hitNormal.x) * slideVelocity;
            movPlayer.z += ((1f-hitNormal.y) * hitNormal.z) * slideVelocity;
            movPlayer.y += slopeForceDown; //fuerza negativa para que empuje como la gravedad
        }
    }
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
        hitNormal = hit.normal; //normal del plano que chocamos

	}
}

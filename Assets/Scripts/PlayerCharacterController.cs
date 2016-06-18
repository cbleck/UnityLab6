using UnityEngine;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour {

    public float speedMovement;
    private CharacterController character;
    private Vector3 vectorMovement; 

	// Use this for initialization
	void Start () {

        character = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        float speedRotation = 50;
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float mouseX = Input.GetAxis("Mouse X");
        float turbo = 1;

        vectorMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.Space))
            turbo = 2;
        else
            turbo = 1;
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime * mouseX);
        vectorMovement = (
            transform.forward * vertical * Time.deltaTime * speedMovement * turbo +
            transform.right * horizontal * Time.deltaTime * speedMovement * turbo
        );
        if (!character.isGrounded)
             vectorMovement.y -= 0.1f;
        else
            if (Input.GetKeyDown(KeyCode.M))
                vectorMovement.y += 5f;
        character.Move(vectorMovement);
	}

    void OnControllerColliderHit(ControllerColliderHit colliderhit)
    {
        if (colliderhit.transform.name == "Cube"){
            colliderhit.transform.GetComponent<MeshRenderer>().material.color = Color.black;

            colliderhit.rigidbody.AddForce(transform.forward*200, ForceMode.Impulse);
        }
    }
}

using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    public float speed;
    private float startTime;
    private bool align, moving;
    private float normalizator;
    private Vector3 startPosition;
    private Vector3 destPosition;
    private Vector3 startForward;
    private Vector3 endForward;
    private float rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (align) {
            transform.LookAt(Vector3.Lerp(startForward, endForward, (Time.time - startTime) * rotationSpeed));
            if ((Time.time - startTime) >= (1 / rotationSpeed)){
                align = false;
                startTime = Time.time;
            }
        }
        else if (moving)
        {
            transform.position = Vector3.Lerp(startPosition, destPosition, (Time.time - startTime) / (normalizator * (1 / speed)));

            if ((Time.time - startTime) >= (normalizator * (1 / speed)))
                moving = false;
        }

	
	}

    public void move(Vector3 endPosition) {

        startTime = Time.time;
        destPosition = endPosition;
        startPosition = transform.position;
        normalizator = Vector3.Magnitude(destPosition-startPosition);
        moving = true;
        align = true;
        startForward = transform.forward;
        startForward.y = 0;
        endForward = destPosition;
        endForward.y = 0;

        rotationSpeed = 10;
    }
}

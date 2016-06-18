using UnityEngine;
using System.Collections;

public class FirstPersonCameraController : MonoBehaviour {

    public float speedRotation;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float mouseY = Input.GetAxis("Mouse Y");
        float angle;

        angle = transform.localEulerAngles.x;
        angle = (angle > 180) ? angle - 360 : angle;

        if (angle > -30f && angle < 50f)
        {
            transform.Rotate(Vector3.left * speedRotation * Time.deltaTime * mouseY);

            angle = transform.localEulerAngles.x;
            angle = (angle > 180) ? angle - 360 : angle;
            if (angle <= -30f && angle >= -50f)
            {
                transform.Rotate(Vector3.left * speedRotation * Time.deltaTime * -mouseY);
            }
            else if (angle >= 50f && angle <= 70f)
            {
                transform.Rotate(Vector3.left * speedRotation * Time.deltaTime * -mouseY);
            }
        }

    }
}

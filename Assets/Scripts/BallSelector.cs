using UnityEngine;
using System.Collections;

public class BallSelector : MonoBehaviour {

    public float rayDistance;
    public float force;
    public GameObject crosshair;
    private GameObject crosshairReference;

    private Camera currentCamera;
    private Ray mouseRay;
    private RaycastHit rayHit;
    private float offset = 0.001f;

    // Use this for initialization
    void Start () {

        currentCamera = GetComponent<Camera>();
        crosshairReference = Instantiate(crosshair);
    }
	
	// Update is called once per frame
	void Update () {
        launchRaycast();
	}

    private void launchRaycast() {

        mouseRay = currentCamera.ScreenPointToRay(Input.mousePosition);
        //If impact with something
        if (Physics.Raycast(mouseRay, out rayHit, rayDistance))
        {
            crosshairReference.SetActive(true);
            crosshairReference.transform.position = rayHit.point + rayHit.normal * offset;
            crosshairReference.transform.rotation = Quaternion.FromToRotation(-Vector3.forward, rayHit.normal);
            Debug.Log(rayHit.transform.name);

            //If left mouse click is down
            if (Input.GetMouseButtonDown(0)) {

                //If impact with sphere tag
                if (rayHit.transform.tag == "Sphere")
                {
                    //rayHit.rigidbody.AddForce(rayHit.transform.forward * force, ForceMode.Acceleration);
                    rayHit.rigidbody.AddForce(-rayHit.normal * force, ForceMode.Acceleration);
                }//end if impact sphere tag

            }//end if impact something

            //If left mouse click is down
            if (Input.GetMouseButtonDown(1))
            {

                //If impact with sphere tag
                if (rayHit.transform.tag == "Sphere")
                {
                    //rayHit.rigidbody.AddForce(rayHit.transform.forward * force, ForceMode.Acceleration);
                    rayHit.rigidbody.AddForce(rayHit.normal * force, ForceMode.Acceleration);
                }//end if impact sphere tag

            }//end if impact something
        }
        else {
            crosshairReference.SetActive(false);
        }

    }
}

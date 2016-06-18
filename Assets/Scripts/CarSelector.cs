using UnityEngine;
using System.Collections;


public enum SelectorState {
    CAR_SELECTION,
    TERRAIN_SELECTION
}

public class CarSelector : MonoBehaviour {

    public SelectorState currentState;
    private GameObject tmpCar;
    private Vector3 destPosition;
    private float velocity;

    private Ray mouseRay;
    private RaycastHit raycastHit;

	// Use this for initialization
	void Start () {

        currentState = SelectorState.CAR_SELECTION;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {

            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out raycastHit)) {

                if (raycastHit.transform.tag == "Car")
                    tmpCar = raycastHit.transform.gameObject;
                //else tmpCar = null;

                switch (currentState) {
                    case SelectorState.CAR_SELECTION:
                        if (tmpCar != null)
                            currentState = SelectorState.TERRAIN_SELECTION;
                        break;
                    case SelectorState.TERRAIN_SELECTION:
                        /*
                        if (tmpCar != null)
                            currentState = SelectorState.CAR_SELECTION;
                        else {*/
                        if (raycastHit.transform.tag != "Car"){
                            destPosition = raycastHit.point;
                            tmpCar.SendMessage("move", destPosition, SendMessageOptions.DontRequireReceiver);
                        }
                        //}
                        break;
                }//End switch current state
            }//Endraycast
        }
	}
}

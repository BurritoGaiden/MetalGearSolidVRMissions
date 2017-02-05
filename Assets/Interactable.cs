using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public enum InteractableState { Active, Activating, inActive, Off};
    public InteractableState current_state = InteractableState.inActive;
    public enum InteractableType { zone, button };
    public InteractableType current_type = InteractableType.button;

    public GameObject objToTrigger;


    public void ThrowTrigger() {
        if (objToTrigger.GetComponent<Door>()) {
            objToTrigger.GetComponent<Door>().Switch();
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (current_type == InteractableType.zone) {

        }


    }
}

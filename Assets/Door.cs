using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Vector3 startMarker;
    public Vector3 endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    public Vector3 closePosition;
    public Vector3 openPosition;

    public enum DoorState { open, close, transitioning };
    public DoorState current_state = DoorState.close;

    public GameObject activator;

    void Update()
    {
        if (Time.time >= .1f)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }

        
    }

    public void Switch() {
        if(transform.position == closePosition || transform.position == openPosition)
        {
            startTime = Time.time;
            startMarker = transform.position;
            if (transform.position == closePosition)
            {
                endMarker = openPosition;
            }
            else if (transform.position == openPosition)
            {
                endMarker = closePosition;
            }
            journeyLength = Vector3.Distance(startMarker, endMarker);
            Invoke("ActivatorCheck", 2);
        }

    }

    public void ActivatorCheck() {
        if (activator.GetComponent<Interactable>().current_state == Interactable.InteractableState.Activating) {
            activator.GetComponent<Interactable>().current_state = Interactable.InteractableState.inActive;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour {

    public Transform startMarker;
    public Vector3 endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    public GameObject player;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= 1)
        {
            startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker.position, endMarker);
            startMarker = this.transform;
            endMarker = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);
        }
    }
}

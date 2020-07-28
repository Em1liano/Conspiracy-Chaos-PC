using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxFactor;

    private Vector3 prevCameraPosition;
    private Vector3 deltaCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        prevCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        deltaCameraPosition = cameraTransform.position - prevCameraPosition;
        Vector3 parallaxPosition = new Vector3(transform.position.x + (deltaCameraPosition.x * parallaxFactor), transform.position.y, transform.position.x);
        transform.position = parallaxPosition;
        prevCameraPosition = cameraTransform.position;
    }
}

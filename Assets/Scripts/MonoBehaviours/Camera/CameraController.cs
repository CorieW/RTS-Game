using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Camera cam;

    [Space]

    public float moveSpeed;
    public float zoomSpeed;

    void Awake()
    {
        if (!cam) {
            cam = this.GetComponent<Camera>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0);
        transform.position += movement;

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + (-Input.mouseScrollDelta.y * zoomSpeed), 5, 25);
    }
}

// TODO - Provide a boundary for where the camera movement can go. This should probably be based on where the objects are scattered on the scene.
// TODO - Scrolling background in the background of the rest of the universe, galaxies?
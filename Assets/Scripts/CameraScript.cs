using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    public float turnSpeed = 4.0f;

	// Use this for initialization
	void Start () {

        offset = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
	
	}
}

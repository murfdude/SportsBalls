using UnityEngine;
using System.Collections;

public class SpectatorCameraScript : MonoBehaviour {

    public float speed;
    Vector3 correctTilt;
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        GetComponent<Rigidbody>().AddForce(transform.forward * moveVertical * speed * Time.deltaTime);
        GetComponent<Rigidbody>().AddForce(transform.right * moveHorizontal * speed * Time.deltaTime);
        GetComponent<Rigidbody>().transform.Rotate(Vector3.up * Time.deltaTime * Input.GetAxis("Mouse X") * 50.0f);

	}
}

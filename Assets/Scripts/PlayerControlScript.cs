using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {

    public float speed;
    public GameObject ball;
    public GameObject cam;
    public float kickSpeed;
    bool canKickFlag = true;
    int KickMaxCD = 150;
    int kickCD;
    int pickupCD;
    public GameObject Pickup;
    public GUIText announcementText;
    public int announcementTextDuration;
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //rotate ball as camera rotates to maintain what 'forward' is
        transform.rotation = cam.transform.rotation;

        //manage movement based on wasd input
        GetComponent<Rigidbody>().AddForce(transform.forward * moveVertical * speed * Time.deltaTime);
        GetComponent<Rigidbody>().AddForce(transform.right * moveHorizontal * speed * Time.deltaTime);

        //cooldown management for player 'kicking'
        if (Input.GetAxis("Jump") == 1 && canKickFlag == true)
        {
            Kick();
            canKickFlag = false;
            kickCD = KickMaxCD;
        }
        if (kickCD <= 0)
        {
            canKickFlag = true;
        }
        if (kickCD > 0)
        {
            kickCD--;
        }



	}

    void Kick()
    {
        Vector3 kickPath = ball.transform.position - transform.position;
        kickPath.Normalize();

        GetComponent<Rigidbody>().AddForce(kickSpeed * kickPath);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenPickup"))
        {
            if (KickMaxCD > 75){
                Pickup = other.gameObject;
                pickupCD = 900;
                other.gameObject.SetActive(false);
                KickMaxCD -= 25;
            }
        }
    }

}

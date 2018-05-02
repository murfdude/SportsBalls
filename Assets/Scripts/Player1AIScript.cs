using UnityEngine;
using System.Collections;

public class Player1AIScript : MonoBehaviour {

    public GameObject opponentGoal;
    public GameObject myGoal;
    public GameObject ball;
    public float speed;
    public float kickSpeed;
    bool canKickFlag = true;
    int KickCD;
    int KickMaxCD = 150;
    Vector3 KickSpot;
    Vector3 ballToOpponentGoal;
    Vector3 meToBall;
    Vector3 meToKickspot;
    int pickupCD;
    public GameObject Pickup;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        ballToOpponentGoal = opponentGoal.transform.position - ball.transform.position;
        ballToOpponentGoal.Normalize();

        meToBall = ball.transform.position - transform.position;
        meToBall.Normalize();

        KickSpot = ball.transform.position - ballToOpponentGoal;
        meToKickspot = KickSpot - transform.position;
        meToKickspot.Normalize();

        if (meToBall == ballToOpponentGoal && canKickFlag)
        {
            Kick();
            KickCD = KickMaxCD;
            canKickFlag = false;
        }
        else if (meToBall == ballToOpponentGoal && !canKickFlag)
        {
            if (Physics.Raycast(transform.position, meToBall, 1, 8))
            {
                GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, Vector3.up) * meToBall * speed * Time.deltaTime);
            }
            GetComponent<Rigidbody>().AddForce(meToBall * speed * Time.deltaTime);
        }
        else if (meToBall != ballToOpponentGoal)
        {
            if (Physics.Raycast(transform.position, meToKickspot, 1, 8))
            {
                GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, Vector3.up) * meToKickspot * speed * Time.deltaTime);
            }
            GetComponent<Rigidbody>().AddForce(meToKickspot * speed * Time.deltaTime);
        }
    }

    void LateUpdate()
    {
        if (KickCD <= 0)
        {
            canKickFlag = true;
        }
        if (KickCD > 0)
        {
            KickCD--;
        }

        if (pickupCD <= 0)
        {
            Pickup.SetActive(true);
        }
        if (pickupCD > 0)
        {
            pickupCD--;
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
            if (KickMaxCD > 75)
            {
                Pickup = other.gameObject;
                pickupCD = 900;
                other.gameObject.SetActive(false);
                KickMaxCD -= 25;
            }
        }
    }
}

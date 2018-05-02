using UnityEngine;
using System.Collections;

public class Player2HardAIScript : MonoBehaviour {

    public GameObject opponentGoal;
    public GameObject myGoal;
    public GameObject ball;
    public float speed;
    public float kickSpeed;
    bool canKickFlag = true;
    int KickCD;
    int KickMaxCD = 150;
    Vector3 KickSpot;
    Vector3 DefendSpot;
    Vector3 ballToOpponentGoal;
    Vector3 ballToMyGoal;
    Vector3 meToBall;
    Vector3 meToKickspot;
    Vector3 meToKickspotMag;
    Vector3 meToDefendSpot;
    Vector3 meToPowerup;
    Vector3 meToPowerupMag;
    Vector3 DefenderLocation;
    Vector3 meToDefenderLocation;
    int pickupCD;
    public GameObject Pickup;
    public int defender;


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
            meToKickspotMag = KickSpot - transform.position;
            meToKickspot.Normalize();

            ballToMyGoal = myGoal.transform.position - ball.transform.position;
            ballToMyGoal.Normalize();

            DefendSpot = ball.transform.position - ballToMyGoal;
            meToDefendSpot = DefendSpot - transform.position;
            meToDefendSpot.Normalize();

            meToPowerup = Pickup.transform.position - transform.position;
            meToPowerupMag = Pickup.transform.position - transform.position;
            meToPowerup.Normalize();
            if (defender == 0)
            {

            if (ball.transform.position.x <= 0)
            {
                if (pickupCD <= 0 && KickMaxCD > 75 && meToPowerupMag.magnitude < meToKickspotMag.magnitude && ball.transform.position.x != 0)
                {
                    if (Physics.Raycast(transform.position, meToPowerup, 1, 8))
                    {
                        GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, Vector3.up) * meToPowerup * speed * Time.deltaTime);
                    }
                    GetComponent<Rigidbody>().AddForce(meToPowerup * speed * Time.deltaTime);
                }
                else if (meToBall == ballToOpponentGoal && canKickFlag)
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
            else if (ball.transform.position.x > 0)
            {
                if (meToBall == ballToOpponentGoal && canKickFlag)
                {
                    Kick();
                    KickCD = KickMaxCD;
                    canKickFlag = false;
                }
                else if (meToBall == -ballToMyGoal && !canKickFlag)
                {
                    if (Physics.Raycast(transform.position, meToBall, 1, 8))
                    {
                        GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, Vector3.up) * meToBall * speed * Time.deltaTime);
                    }
                    GetComponent<Rigidbody>().AddForce(meToBall * speed * Time.deltaTime);
                }
                else if (meToBall != -ballToMyGoal)
                {
                    if (Physics.Raycast(transform.position, meToDefendSpot, 1, 8))
                    {
                        GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, Vector3.up) * meToDefendSpot * speed * Time.deltaTime);
                    }
                    GetComponent<Rigidbody>().AddForce(meToDefendSpot * speed * Time.deltaTime);
                }
            }
        }
        else if (defender == 1)
        {
            if (ball.transform.position.x < 18)
            {
                if (ball.transform.position.z > 0)
                {
                    if (ball.transform.position.z > 3.5)
                    {
                        DefenderLocation = new Vector3(transform.position.x, transform.position.y, ball.transform.position.z);
                    }
                    else
                    {
                        DefenderLocation = new Vector3(18f, transform.position.y, 3.5f);
                    }
                }
                if (ball.transform.position.z < 0)
                {
                    if (ball.transform.position.z < -3.5)
                    {
                        DefenderLocation = new Vector3(transform.position.x, transform.position.y, ball.transform.position.z);
                    }
                    else
                    {
                        DefenderLocation = new Vector3(18f, transform.position.y, -3.5f);
                    }
                }

                meToDefenderLocation = DefenderLocation - transform.position;
                meToDefenderLocation.Normalize();

                GetComponent<Rigidbody>().AddForce(meToDefenderLocation * speed * Time.deltaTime);
            }
            else if (ball.transform.position.x > 18)
            {
                if (canKickFlag)
                {
                    Kick();
                    KickCD = KickMaxCD;
                    canKickFlag = false;
                }
                else if (meToBall == -ballToMyGoal)
                {
                    if (Physics.Raycast(transform.position, meToBall, 1, 8))
                    {
                        GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, Vector3.up) * meToBall * speed * Time.deltaTime);
                    }
                    GetComponent<Rigidbody>().AddForce(meToBall * speed * Time.deltaTime);
                }
                else if (meToBall != -ballToMyGoal)
                {
                    if (Physics.Raycast(transform.position, meToDefendSpot, 1, 8))
                    {
                        GetComponent<Rigidbody>().AddForce(Quaternion.AngleAxis(-45, Vector3.up) * meToDefendSpot * speed * Time.deltaTime);
                    }
                    GetComponent<Rigidbody>().AddForce(meToDefendSpot * speed * Time.deltaTime);
                }
            }
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
        if (other.gameObject.CompareTag("RedPickup"))
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

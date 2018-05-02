using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    public GameObject Player1, Player2, Ball, Goal1, Goal2, Canvas, greenPickup, redPickup;
    public Vector3 BallInitial, Player1Initial, Player2Initial;
    public GUIText timerText;
    public GUIText scoreText;
    public GUIText announcementText;
    public int announcementTextDuration;
    int timer = 36000;
    int redPickupTimer;
    int greenPickupTimer;
    bool timerActive = true;
    private int greenScore, redScore;


    void Start()
    {
        timerText.text = "Time: " + ((int)(timer / 300)).ToString();
        scoreText.text = "Green: " + greenScore + "\t Red: " + redScore;
        announcementText.text = "";
        BallInitial = Ball.transform.position;
        Player1Initial = Player1.transform.position;
        Player2Initial = Player2.transform.position;
        timerActive = true;
    }
	// Update is called once per frame
	void Update () {

        timerText.text = "Time: " + ((int)(timer / 300)).ToString();
        scoreText.text = "Green: " + greenScore + "\t Red: " + redScore;

        //game clock countdown 
        if (timer > 0 && timerActive)
        {
            timer -= 4;
        }
        if (timer == 0)
        {
            GameOver();
        }

        //Timer to remove goal announcements
        if (announcementTextDuration > 0)
        {
            announcementTextDuration--;
        }
        if (announcementTextDuration == 0)
        {
            announcementText.text = "";
        }

        //call GameOver() if either player gets two goals
        if (redScore == 2 || greenScore == 2)
        {
            GameOver();
        }

        //pseudo stop players from moving after game is over
        if (!timerActive)
        {
            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

	}

    void GameOver()
    {

        timerActive = false;

        //catch which game ending occured
        if (timer == 0)
        {
            if (redScore == greenScore)
            {
                announcementText.text = "Tie Game, Red Wins by Default!";
            }
            else if (redScore > greenScore){
                announcementText.text = "Red Wins!";
            }
            else if (greenScore > redScore)
            {
                announcementText.text = "Green Wins!";
            }
        }
        else if (redScore == 2)
        {
            announcementText.text = "Red Wins!";
        }
        else if (greenScore == 2)
        {
            announcementText.text = "Green Wins!";
        }

        Canvas.SetActive(true);


    }

    public void RedScored()
    {
        redScore++;

        //ball reset
        Ball.transform.position = BallInitial;
        Ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        //player1 reset
        Player1.transform.position = Player1Initial;
        Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        //player2 reset
        Player2.transform.position = Player2Initial;
        Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        announcementText.text = "Red Scored!";
        announcementTextDuration = 90;

    }

    public void GreenScored()
    {
        greenScore++;

        //ball reset
        Ball.transform.position = BallInitial;
        Ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        //player1 reset
        Player1.transform.position = Player1Initial;
        Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        //player2 reset
        Player2.transform.position = Player2Initial;
        Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        announcementText.text = "Green Scored!";
        announcementTextDuration = 90;
    }

}

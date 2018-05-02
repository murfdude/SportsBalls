using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    public GameObject greenUpgrade;
    int step = 0;
    public GUIText announcementText;
    public GameObject canvas;


	void Update () {

        switch (step)
        {
            case 0:
                    announcementText.text = "Move your mouse to look around";
                    if (Input.GetAxis("Mouse X") > 0)
                    {
                        step++;
                    }
                break;

            case 1:
                    announcementText.text = "Use WASD to move your player";
                    if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
                    {
                        step++;
                    }

                break;

            case 2:
                    ball.SetActive(true);
                    announcementText.text = "Hit this white ball into the other player's goal";
                    if(ball.transform.position.x != 0){
                        step++;
                    }
                break;

            case 3:
                    announcementText.text = "You can press the space bar 'Kick' at the ball";
                    if (Input.GetAxis("Jump") == 1)
                    {
                        step++;
                    }
                break;

            case 4:
                greenUpgrade.SetActive(true);
                announcementText.text = "Touching this box will lower your kick cooldown";
                if ( player1.transform.position.x < 10.5f && player1.transform.position.x  > 9.5f && player1.transform.position.z < 0.5f && player1.transform.position.z > -0.5f)
                {
                    step++;
                }
                break;

            case 5:
                player2.SetActive(true);
                canvas.SetActive(true);
                announcementText.text = "This red ball is the other player";
                break;

        }



	}
	

}

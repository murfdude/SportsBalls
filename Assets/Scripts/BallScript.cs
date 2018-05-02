using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public ControllerScript controller;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GreenGoal")
        {
            controller.RedScored();
        }
        if (other.gameObject.tag == "RedGoal")
        {
            controller.GreenScored();
        }
    }

}

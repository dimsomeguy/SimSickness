using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTrigger : MonoBehaviour 
{
    private AudioSource Ding;


	// Use this for initialization
	void Start ()
    {
        Ding = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        GameObject WP = GameObject.Find("WayPointController");
        if (collision.gameObject.tag == "Player")
        {
            Waypoint controller = WP.GetComponent<Waypoint>();
            controller.playerPoint++;
            controller.WayPointVisable();
            //Debug.Log("collider is hitting object great job");

            Destroy(this.gameObject);
        }
    }
}

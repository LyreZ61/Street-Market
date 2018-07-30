using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPeople : MonoBehaviour {

    public float speed = 3f;

    private Collider2D people;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (people == null)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        people = collision;
    }
}

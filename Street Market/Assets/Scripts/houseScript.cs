using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class houseScript : MonoBehaviour {

    public float speed = 2f;
    public Vector3 diff;    //Differenz um den Position unter dem Haus zu haben.
    private Collider2D people=null;
    private Vector3 posa;
    private Vector3 posb;
    

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if(people != null)
        {
            posa = transform.position;
            var movement = Vector2.MoveTowards(posb, posa-diff, Time.deltaTime * speed);
            people.transform.position = movement;
        }	
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        people = collision;
        posb = collision.transform.position;
        
        
    }



}

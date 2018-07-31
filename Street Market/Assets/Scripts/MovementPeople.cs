using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPeople : MonoBehaviour {

    public float speed = 1f;
    public Vector3 diff;    //Differenz um den Position unter dem Haus zu haben.
    public float HausWait;

    public bool HausGefuden = false;
    private Collider2D people;
    private Vector3 posa;
    private Vector3 posb;

    // Update is called once per frame
    void Update()
    {
        if (people != null && HausGefuden == true)
        {
            posa = people.transform.position - diff;
            var movement = Vector2.MoveTowards(posb, posa, Time.deltaTime * speed);
            transform.position = movement;
            if (posb.x == posa.x && posa.y == posb.y)
            {
                StartCoroutine(WaitForHausTime(HausWait));
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HausGefuden = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (HausGefuden)
        {
            people = collision;
            posb = transform.position;
        }
    }

    // every 2 seconds perform the print()
    private IEnumerator WaitForHausTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        int GeldBekommen = people.GetComponent<houseScript>().GeldBekommen;
        FindObjectOfType<TheGameSystem>.
        HausGefuden = false;
    }
}

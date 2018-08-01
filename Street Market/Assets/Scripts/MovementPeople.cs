using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPeople : MonoBehaviour {

    public float speed = 1f;
    public Vector3 diff;    //Differenz um den Position unter dem Haus zu haben.
    public float HausWait;

    public bool HausGefuden = false;
    private Collider2D people;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 PosBef;
    private int SwitchInput;

    // Update is called once per frame
    void Update()
    {
        switch (SwitchInput)
        {
            case 0: //Normal Laufen
                if (people != null && HausGefuden == true)
                {

                    SwitchInput = 1;
                    return;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                break;
            case 1: //Zu Haus Laufen
                posB = people.transform.position - diff;
                var movement = Vector2.MoveTowards(posA, posB, Time.deltaTime * speed);
                transform.position = movement;
                if (posB.x == posA.x && posA.y == posB.y)
                {
                    SwitchInput = 2;
                    PosBef = new Vector3(posB.x + posB.x - PosBef.x, PosBef.y, PosBef.z);
                    StartCoroutine(WaitForHausTime(HausWait));
                    return;
                }
                break;
            case 2: //Nichts

                break;
            case 3: //Zurück zu Weg Laufen
                posA = transform.position;
                posB = PosBef;
                var movement2 = Vector2.MoveTowards(posA, posB, Time.deltaTime * speed);
                transform.position = movement2;
                if (posB.x == posA.x && posA.y == posB.y)
                {
                    SwitchInput = 0;
                    return;
                }
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PosBef = transform.position;
        HausGefuden = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (HausGefuden)
        {
            people = collision;
            posA = transform.position;
        }
    }

    private IEnumerator WaitForHausTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        int GeldBekommen = people.GetComponent<houseScript>().GeldBekommen;
        FindObjectOfType<TheGameSystem>().GoldVerdient(GeldBekommen);
        HausGefuden = false;
        SwitchInput = 3;
    }
}

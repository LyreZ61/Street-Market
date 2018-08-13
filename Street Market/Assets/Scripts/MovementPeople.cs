using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPeople : MonoBehaviour {

    public float speed = 1f;
    public Vector3 diff;    //Differenz um den Position unter dem Haus zu haben.

    public bool HausGefuden = false;
    private Collider2D NewHaus;
    private Collider2D OldHaus;
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
                if (NewHaus != null && HausGefuden == true && transform.position.x > NewHaus.transform.position.x)
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
                posA = transform.position;
                var movement = Vector2.MoveTowards(posA, posB, Time.deltaTime * speed);
                transform.position = movement;
                if (posB.x == posA.x && posA.y == posB.y)
                {
                    PosBef = new Vector3(posB.x + Mathf.Abs((posB.x - PosBef.x)), PosBef.y, PosBef.z);
                    if (NewHaus.GetComponent<houseScript>().MyPeopleAnzahl < NewHaus.GetComponent<houseScript>().MaxPeople)
                    {
                        StartCoroutine(WaitForHausTime(NewHaus.GetComponent<houseScript>().HausWait)); //Warten
                        NewHaus.GetComponent<houseScript>().PeopleRefresh(1); //People +1
                        if (NewHaus.GetComponent<houseScript>().ReinGehen == true) //Wenn Haus nicht voll ist
                        {
                            gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        }
                        SwitchInput = 2;
                    }
                    else
                    {
                        HausGefuden = false;
                        NewHaus = null;
                        OldHaus = NewHaus;
                        SwitchInput = 3;
                    }
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

    private IEnumerator WaitForHausTime(float waitTime) //Warten
    {
        yield return new WaitForSeconds(waitTime);
        int GeldBekommen = NewHaus.GetComponent<houseScript>().GeldBekommen;
        FindObjectOfType<TheGameSystem>().MoneyVerdient(GeldBekommen);
        HausGefuden = false;
        NewHaus.GetComponent<houseScript>().PeopleRefresh(-1); //People -1
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        SwitchInput = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PosBef = transform.position;
        NewHaus = collision;
        posB = NewHaus.transform.position - diff;
        HausGefuden = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        NewHaus = collision;
        posB = NewHaus.transform.position - diff;
    }


}

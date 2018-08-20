using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPeople : MonoBehaviour {

    public float speed = 1f;
    public Vector3 diff;    //Differenz um den Position unter dem Haus zu haben.

    public bool HausGefuden = false;
    public GameObject MyImage;
    public GameObject Sprechblase;
    public float SprechblaseTimer = 3f;

    private Collider2D NewHaus;
    //private Collider2D OldHaus;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 PosBef;
    private int SwitchInput;

    private void Start()
    {
        FindObjectOfType<TheGameSystem>().BedurfnisRandomize();
    }

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
                    if (FindObjectOfType<CameraMovement>().xClampValue.y + 58 < transform.position.x)
                    {
                        TheGameSystem.PeopleInScreen--;
                        if (TheGameSystem.PeopleInScreen == 0)
                        {
                            FindObjectOfType<TheGameSystem>().StartNewSound("Music1", 50f);
                        }
                            
                        Destroy(gameObject);
                        return;
                    }
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
                    if (NewHaus.GetComponent<houseScript>().MyPeopleAnzahl < NewHaus.GetComponent<houseScript>().MaxPeople) //Wenn Haus nicht voll ist
                    {
                        StartCoroutine(WaitForHausTime(NewHaus.GetComponent<houseScript>().HausWait)); //Warten
                        NewHaus.GetComponent<houseScript>().PeopleRefresh(1); //People +1
                        if (NewHaus.GetComponent<houseScript>().ReinGehen == true) //Ób man Reingehen soll.
                        {
                            MyImage.SetActive(false);
                        }
                        SwitchInput = 2;
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().PlayAndStop("Sad1 - Female", Random.Range(-0.1f, 0.1f)); //Play Sound: Coin
                        HausGefuden = false;
                        NewHaus = null;
                        //OldHaus = NewHaus;
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
        MyImage.SetActive(true);

        FindObjectOfType<AudioManager>().PlayAndStop("Coin1",Random.Range(-0.1f,0.1f)); //Play Sound: Coin

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

        private float Wave(float a, float b, float seconds, float amount)
    {
        float a4 = (b - a) * 0.5f;
        return a + a4 + Mathf.Sin((((Time.deltaTime * 0.001f) + seconds * amount) / seconds) * (Mathf.PI * 2)) * a4;
    }

    //Show Sprechblase


    private void OnMouseDown()
    {
        Sprechblase.SetActive(true);
        StartCoroutine(ShowIconTimer(SprechblaseTimer));
    }

    private IEnumerator ShowIconTimer(float waitTime) //Warten
    {
        yield return new WaitForSeconds(waitTime);
        Sprechblase.SetActive(false);
    }

}

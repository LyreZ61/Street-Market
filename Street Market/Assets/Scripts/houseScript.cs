using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class houseScript : MonoBehaviour {

    public int GeldBekommen = 50;
    public Image img;
    public float MaxPeople = 5;
    public float HausWait;
    public bool ReinGehen = true;
    public TextMeshProUGUI Text;
    private float ProPeople;

    public int MyPeopleAnzahl;

    private void Start()
    {
        Text.text = "0 / " + MaxPeople.ToString();
        img.fillAmount = 0f;
        ProPeople = 1/MaxPeople;
    }

    public void PeopleRefresh(int People)
    {
        MyPeopleAnzahl += People;
        img.fillAmount = ProPeople* MyPeopleAnzahl;
        Text.text = MyPeopleAnzahl.ToString() + " / " + MaxPeople.ToString();
    }

}

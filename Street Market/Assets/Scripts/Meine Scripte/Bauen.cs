﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bauen : MonoBehaviour {

    public TextMeshProUGUI Text;
    public shop shopp;
    public int houseNumber;

    public void Start()
    {
        Text.text = shopp.standardHouse[houseNumber].cost.ToString()+"$";
    }


    public void HausBauen()
    {
        /*
        GameObject.Find("BauOrt").SetActive(true);
        GameObject[] BauSelect = GameObject.FindGameObjectsWithTag("BauObjekt");
        int heyy = BauSelect.Length;
        foreach (GameObject BauOrte in BauSelect)
        {
            BauOrte.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            Debug.Log("Die Länge von dem Array beträgt: " + BauSelect.Length.ToString());
        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bauen : MonoBehaviour {

    public void HausBauen()
    {
        GameObject.Find("BauOrt").SetActive(true);
        GameObject[] BauSelect = GameObject.FindGameObjectsWithTag("BauObjekt");
        int heyy = BauSelect.Length;
        foreach (GameObject BauOrte in BauSelect)
        {
            BauOrte.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            Debug.Log("Die Länge von dem Array beträgt: " + BauSelect.Length.ToString());
        }


    }
}

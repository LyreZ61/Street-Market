using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TheGameSystem : MonoBehaviour {
  
    public TextMeshProUGUI Gold_Text;
    public TextMeshProUGUI Wave;
    public static int Money;
    public int startMoney = 400;
    public int[] People;

    public GameObject CurrentBildschirm;
    public GameObject OutroBildschirm;

    private int currentWave;
    public GameObject SpawnObject;
    public float SpawnTimer = 10f;
    public Vector3 SpawnPoint;

    private void Start()
    {
        Money = startMoney;
        Gold_Text.text = "Gold :" + Money.ToString() + "$";
        Wave.text = "Day " + (currentWave).ToString()+"!";
    }

    public void MoneyVerdient(int Goldplus)
    {
        Money += Goldplus;
        Gold_Text.text = "Gold :" + Money.ToString()+"$";
    }

    public void MoneyVerloren(int Goldplus)
    {
        Money -= Goldplus;
        Gold_Text.text = "Gold :" + Money.ToString() + "$";
    }

    public void NextWave()
    {
        if (People[currentWave] <= 0 || currentWave == 0)
        {
            if (currentWave < People.Length-1)
            {
                currentWave++;
                Wave.text = "Day " + (currentWave).ToString() + "!";
                StartCoroutine(SpawnSystem(SpawnTimer));
            }
            else
            {
                CurrentBildschirm.SetActive(false);
                OutroBildschirm.SetActive(true);
            }
        }  
    }

    private IEnumerator SpawnSystem(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (People[currentWave] > 0)
        {
            People[currentWave] -= 1;
            Instantiate(SpawnObject, SpawnPoint, transform.rotation);
            StartCoroutine(SpawnSystem(SpawnTimer));
        }

    }
}

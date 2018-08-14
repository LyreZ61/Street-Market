using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TheGameSystem : MonoBehaviour {
  
    public TextMeshProUGUI Gold_Text;
    public TextMeshProUGUI WaveText;
    public static int Money;
    public int startMoney = 400;

    public GameObject CurrentBildschirm;
    public GameObject OutroBildschirm;

    private int currentWave;
    public GameObject SpawnObject;
    public float SpawnTimer = 10f;

    public Vector3 SpawnPoint;

    public Wave[] waves; // wavespawner 2.0

    private void Start()
    {
        Wave wave = waves[currentWave];
        Money = startMoney;
        Gold_Text.text = "Gold :" + Money.ToString() + "$";
        WaveText.text = "Day " + currentWave.ToString()+"!";
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

    private bool WaveDone = true;

    public void NextWave()
    {
        Wave wave = waves[currentWave];
        if (WaveDone)
        {
            if (currentWave <= waves.Length-1)
            {
                WaveText.text = "Day " + currentWave.ToString() + "!";
                StartCoroutine(SpawnSystem(SpawnTimer));
                WaveDone = false;
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

        Wave wave = waves[currentWave];
        for (int i = 0; i < wave.count; i++)
        {
            int peopleID = Random.Range(0, wave.people.Length);
            Instantiate(wave.people[peopleID], SpawnPoint, transform.rotation);
            yield return new WaitForSeconds(1f / wave.rate);        //wavespaner 2.0
        }
        WaveDone = true;
        currentWave++;
    }



}
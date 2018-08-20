using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TheGameSystem : MonoBehaviour {

    public static int PeopleInScreen;
    public BedurfnisSystem bedurfnis;
    public string currentMusic;

    [Header("Level Values")]
    public TextMeshProUGUI Gold_Text;
    public TextMeshProUGUI WaveText;
    public static int Money;
    public int startMoney = 400;
    

    [Header("Outro Window")]
    public GameObject CurrentBildschirm;
    public GameObject OutroBildschirm;

    [Header("Spawn People")]
    private int currentWave;
    public float SpawnTimer = 10f;

    public Vector3 SpawnPoint;

    public Wave[] waves; // wavespawner 2.0

    private void Start()
    {
        StartNewSound(null, 50f);
        Money = startMoney;
        Gold_Text.text = "Gold :" + Money.ToString() + "$";
        WaveText.text = "Day " + currentWave.ToString()+"!";
    }

    public void MoneyVerdient(int Moneyplus)
    {
        
        Money += Moneyplus;
        Gold_Text.text = "Gold :" + Money.ToString()+"$";
    }

    public void MoneyVerloren(int Moneyminus)
    {
        
        Money -= Moneyminus;
        Gold_Text.text = "Gold :" + Money.ToString() + "$";
    }

    private bool WaveDone = true;

    
    //Spawn System

    public void NextWave()
    {
        if (WaveDone && PeopleInScreen <= 0)
        {
            if (currentWave <= waves.Length-1)
            {
                StartNewSound("Music2", 50f);
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
            PeopleInScreen++;
            int GeschlechtRandomize = Random.Range(0, wave.people.Length);
            var peopleSpawned = Instantiate(wave.people[GeschlechtRandomize], SpawnPoint, transform.rotation);
            peopleSpawned.GetComponent<ClothesRandomize>().GeschlechtValue = GeschlechtRandomize;

            yield return new WaitForSeconds(1f / wave.rate);        //wavespaner 2.0
        }
        WaveDone = true;
        currentWave++;
    }

    public int[] BedurfnisRandomize()
    {
        int[] ValueOfBedurfnis = { 0, 2, 3, 1 };
        for (int i = 0; i < ValueOfBedurfnis.Length; i++)
        {
            ValueOfBedurfnis[i] = Random.Range(0, 5);
            Debug.Log(i.ToString() + " ArrayIndex is: " + ValueOfBedurfnis[i].ToString() +" ,");
        }
        return ValueOfBedurfnis;
    }

    public void StartNewSound(string name, float TimeForSmoothBegin)
    {
        var MyAudio = FindObjectOfType<AudioManager>();
        if (name == null)
        {
            MyAudio.StartCoroutine(MyAudio.StartMusic(currentMusic, TimeForSmoothBegin));
        }
        else
        {
            MyAudio.StartCoroutine(MyAudio.StartNewSound(currentMusic, name, TimeForSmoothBegin));
            currentMusic = name;
        }
    }

}
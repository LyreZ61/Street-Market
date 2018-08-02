using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TheGameSystem : MonoBehaviour {
  
    public TextMeshProUGUI Gold_Text;
    public TextMeshProUGUI Wave;
    public int Gold = 0;
    public int[] People;

    private int currentWave;
    public GameObject SpawnObject;
    public float SpawnTimer = 10f;
    public Vector3 SpawnPoint;

    private void Start()
    {
        Wave.text = "Wave : " + (currentWave+1).ToString();
        StartCoroutine(SpawnSystem(SpawnTimer));
    }

    public void GoldVerdient(int Goldplus)
    {
        Gold += Goldplus;
        Gold_Text.text = "Gold :" + Gold.ToString()+"$";
    }

    public void NextWave()
    {
        if (People[currentWave] <= 0)
        {
            currentWave++;
            Wave.text = "Wave : " + (currentWave + 1).ToString();
            StartCoroutine(SpawnSystem(SpawnTimer));
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

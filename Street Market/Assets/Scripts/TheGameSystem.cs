using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TheGameSystem : MonoBehaviour {
  
    public TextMeshProUGUI Gold_Text;
    public int Gold = 0;
    public GameObject SpawnObject;
    public float SpawnTimer = 10f;
    public Vector3 SpawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnSystem(SpawnTimer));
    }

    public void GoldVerdient(int Goldplus)
    {
        Gold += Goldplus;
        Gold_Text.text = "Gold :" + Gold.ToString();
    }

    private IEnumerator SpawnSystem(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(SpawnObject, SpawnPoint, transform.rotation);
        StartCoroutine(SpawnSystem(SpawnTimer));
    }
}

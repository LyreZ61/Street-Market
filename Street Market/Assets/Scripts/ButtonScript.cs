using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {


    public int MenschenAnzahl;
    public GameObject go;

    private int blabla;
    public float ss = 10.5f;
    public bool booling = false;

    public void MoveToScene(int SceneZahl)
    {
        SceneManager.LoadScene(SceneZahl);
    }

    void Start () {
        go.transform.position = new Vector3(1, 1, 1);
	}
	
	void FixedUpdate () {
		
	}

}

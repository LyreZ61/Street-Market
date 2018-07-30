using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {


    public int MenschenAnzahl;
    public GameObject go;


    private void Awake()
    {
        
    }

    void Start () {
        go.transform.position = new Vector3(1, 1, 1);
	}
	
	void FixedUpdate () {
		
	}

}

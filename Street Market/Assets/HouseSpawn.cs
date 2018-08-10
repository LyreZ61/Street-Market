using UnityEngine;

public class HouseSpawn : MonoBehaviour {

    public Color hoverColor;

    public GameObject house;



    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (house != null)
        {
            Debug.Log("Cant´t build there! - TODO : Display on screen");
            return;
        }
        GameObject houseToBuild = BuildManager.instance.GetHouseToBuild();
        house =(GameObject)Instantiate(houseToBuild, transform.position, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

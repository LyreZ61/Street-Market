using UnityEngine;


public class HouseSpawn : MonoBehaviour {

    public Color hoverColor;

    public GameObject house;



    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {


        if (buildManager.GetHouseToBuild() == null)
            return;

        if (house != null)
        {
            Debug.Log("Cant´t build there! - TODO : Display on screen");
            return;
        }
        GameObject houseToBuild = buildManager.GetHouseToBuild();
        house = (GameObject)Instantiate(houseToBuild, transform.position, transform.rotation);
        buildManager.SetHouseToBuild(null);
    }

    private void OnMouseEnter()
    {
   

        if (buildManager.GetHouseToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

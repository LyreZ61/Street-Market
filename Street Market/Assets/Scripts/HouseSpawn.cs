﻿using UnityEngine;


public class HouseSpawn : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject house;

    [HideInInspector]
    public HouseBluePrint houseBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;  // shop (placement of items)


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;  //shop (placement of items)
    }                                                           //----farbe bis oben Kommentar (gehört zusammen)

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    { 
        if (house != null)
        {

            buildManager.SelectHouse(this);
            Debug.Log("Cant´t build there! - TODO : Display on screen");
            return;
        }

        if (!buildManager.CanBuild)
            return;


        //buildManager.BuildHouseOn(this);
        BuildHouse(buildManager.GetHouseToBuild());
    }


    void BuildHouse(HouseBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough to build that!");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _house = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);           //GameObject turretToBuild = buildManager.GetTurretToBuild();
        house = _house;                                                                                            //turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

        houseBlueprint = blueprint;

        /*GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);     // effect für buildeffect
        Destroy(effect, 5f);*/

        Debug.Log("Turret build! Money left:" + PlayerStats.Money);

    }

    public void UpgradeHouse()
    {
        if (PlayerStats.Money < houseBlueprint.upgradeCost)
        {
            Debug.Log("Not enough to upgrade that!");
            return;
        }
        PlayerStats.Money -= houseBlueprint.upgradeCost;

        //Get rid of the old turret
        Destroy(house);

        //Build a new one
        GameObject _house = (GameObject)Instantiate(houseBlueprint.upgradedPrefap, GetBuildPosition(), Quaternion.identity);           //GameObject turretToBuild = buildManager.GetTurretToBuild();
        house = _house;                                                                                            //turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

        /*GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);     // effect für buildeffect
        Destroy(effect, 5f);*/

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellHouse()
    {
        PlayerStats.Money += houseBlueprint.GetSellAmount();   //verkaufen gibt dir die häflte verbunden mit turretblueprint.

        /*GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);     // effect für selleffect
        Destroy(effect, 5f);*/


        Destroy(house);
        houseBlueprint = null;
    }
    private void OnMouseEnter()
    {
   


        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

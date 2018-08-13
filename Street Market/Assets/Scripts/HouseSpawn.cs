using UnityEngine;


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
    private TheGameSystem game;
    private Color startColor;

    BuildManager buildManager;  // shop (placement of items)


    private void Start()
    {
        game = FindObjectOfType<TheGameSystem>();
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
        if (TheGameSystem.Money < blueprint.cost)
        {
            Debug.Log("Not enough to build that!");
            return;
        }
        game.MoneyVerloren(blueprint.cost);

        GameObject _house = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);           //GameObject turretToBuild = buildManager.GetTurretToBuild();
        house = _house;                                                                                            //turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

        houseBlueprint = blueprint;
        buildManager.SelectHouseToBuild(null);                                                                      //deselct nach klick fürs bauen.
        /*GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);     // effect für buildeffect
        Destroy(effect, 5f);*/

        Debug.Log("Turret build! Money left:" + TheGameSystem.Money);

    }

    public void UpgradeHouse()
    {
        if (TheGameSystem.Money < houseBlueprint.upgradeCost)
        {
            Debug.Log("Not enough to upgrade that!");
            return;
        }
        game.MoneyVerloren(houseBlueprint.upgradeCost);

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
        game.MoneyVerdient(houseBlueprint.GetSellAmount());   //verkaufen gibt dir die häflte verbunden mit turretblueprint.

        /*GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);     // effect für selleffect
        Destroy(effect, 5f);*/

        isUpgraded = false;
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

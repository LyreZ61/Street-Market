using UnityEngine;
using UnityEngine.EventSystems;
/*private void OnMouseEnter()                               ist dazu da um mit dem maus beim drüber gehen etwas zu makieren
                                                                stattdesssen wird etwas effiezenteres werdendet
    {                                                           die untere funktion kann es in einem chache rein tuen
        GetComponent<Renderer>().material.color = hoverColor;   um es stabiler zumachen.
    }*/

public class WayPoints : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public BuildBluePrint buildBluePrint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;                                   // dazu da um beim rüber gehen sachen farblich... 

    BuildManager buildManager; // shop (placement of items)

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




    private void OnMouseDown()                  //wenn der maus geklickt wird dann...
    {
        if (EventSystem.current.IsPointerOverGameObject()) // ist dazu da wenn die UI mit der Welt überlappt wird das pressment im Hintergrund verhindert. Sozusagen das was man im Hintergrund klicken kann wird ignoriert stattdessen wird das Panel UI benutzt.
            return;

        /*if (buildManager.GetTurretToBuild() == null)  //shop (placement of items)
            return;*/


        if (turret != null)
        {
            Debug.Log("Can´t build there! - TODO: Display on screen.");
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        //Build a turret.

        //buildManager.BuildTurretOn(this);
        /*GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);*/

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(BuildBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough to build that!");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);           //GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = _turret;                                                                                            //turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

        buildBluePrint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);     // effect für buildeffect
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left:" + PlayerStats.Money);

    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < buildBluePrint.upgradeCost)
        {
            Debug.Log("Not enough to upgrade that!");
            return;
        }
        PlayerStats.Money -= buildBluePrint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(buildBluePrint.upgradedPrefap, GetBuildPosition(), Quaternion.identity);           //GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = _turret;                                                                                            //turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);



        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);     // effect für buildeffect
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += buildBluePrint.GetSellAmount();   //verkaufen gibt dir die häflte verbunden mit turretblueprint.

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);     // effect für selleffect
        Destroy(effect, 5f);


        Destroy(turret);
        buildBluePrint = null;
    }

    private void OnMouseEnter()                                 //---- farbe bis unten Kommentar (gehört zusammen)
    {
        if (EventSystem.current.IsPointerOverGameObject()) // ist dazu da wenn die UI mit der Welt überlappt wird das pressment im Hintergrund verhindert. Sozusagen das was man im Hintergrund klicken kann wird ignoriert stattdessen wird das Panel UI benutzt.
            return;

        /* if (buildManager.GetTurretToBuild() == null)  //shop (placement of items)
             return;
         */

        if (!buildManager.CanBuild)
            return;
        //rend.material.color = hoverColor;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;                       // ...zu makieren
    }
}

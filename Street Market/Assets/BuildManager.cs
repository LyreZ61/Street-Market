using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;

    }



    /* private void Start()                  //dazu da etwas am anfang selected zu haben um es nach klicken zu bauen.
     {
         turretToBuild = standardTurretPrefab;
     } */

    /*public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;*/

    public GameObject buildEffect;
    public GameObject sellEffect;



    private BuildBluePrint turretToBuild;          //private Gameobject turretToBuild;
    private WayPoints selectedwaypoints;

    public UIBuy uibuy;

    /*public GameObject GetTurretToBuild() // wird nicht mehr gebraucht da wir ein buy system bauen
    {
        return turretToBuild;
    }*/

    /*public void SetTurretToBuild(GameObject turret)  //hat mit dem shop etwas zutun 
    {
        turretToBuild = turret;
    }*/

    public bool CanBuild { get { return turretToBuild != null; } }  //buysystem
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }  //buysystem


    public void SelectNode(WayPoints waypoints)
    {
        if (selectedwaypoints == waypoints)
        {
            DeselectWayPoint();
            return;
        }

        selectedwaypoints = waypoints;
        turretToBuild = null;

        uibuy.SetTarget(waypoints);
    }

    public void DeselectWayPoint()
    {
        selectedwaypoints = null;
        uibuy.Hide();
    }

    public void SelectTurretToBuild(BuildBluePrint turret)
    {
        turretToBuild = turret;
        DeselectWayPoint();
    }


    public BuildBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }

}

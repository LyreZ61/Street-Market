using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in Scene");
            return;
        }

        instance = this;
    }

    private HouseBluePrint houseToBuild;
    private HouseSpawn selectedHouseSpawn;

    public UpSellUI upSellUI;

    public bool CanBuild { get { return houseToBuild != null; } }  //buysystem
    public bool HasMoney { get { return PlayerStats.Money >= houseToBuild.cost; } }  //buysystem

    public void SelectHouse(HouseSpawn houseSpawn)
    {
        if (selectedHouseSpawn == houseSpawn)
        {
            DeselectNode();
            return;
        }
        selectedHouseSpawn = houseSpawn;
        houseToBuild = null;

        upSellUI.SetTarget(houseSpawn);
    }

    public void DeselectNode()
    {
        selectedHouseSpawn = null;
        upSellUI.Hide();
    }

    public void SelectHouseToBuild(HouseBluePrint house)
    {
        houseToBuild = house;
        DeselectNode();
    }


    public HouseBluePrint GetHouseToBuild()
    {
        return houseToBuild;
    }

}

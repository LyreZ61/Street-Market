using UnityEngine;

public class shop : MonoBehaviour
{
    public HouseBluePrint standardHouse;
    //public BuildBluePrint standardHouse; weiter einfügen.

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardHouse()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectHouseToBuild(standardHouse);             // ohne buy system buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
        
    }
    //hier weitere einfügen.
    /* public void SelectStandardHouse()
     {
         Debug.Log("Standard Turret Selected");
         buildManager.SelectHouseToBuild(standardHouse);          // ohne buy system buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);

     }
     */
}
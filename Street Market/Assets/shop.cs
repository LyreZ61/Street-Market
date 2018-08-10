using UnityEngine;

public class shop : MonoBehaviour
{
    public BuildBluePrint standardHouse;
    //public BuildBluePrint standardHouse; weiter einfügen.

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardHouse()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetHouseToBuild(buildManager.standardHousePrefab);          // ohne buy system buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);

    }
    //hier weitere einfügen.
   /* public void SelectStandardHouse()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetHouseToBuild(buildManager.standardHousePrefab);          // ohne buy system buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);

    }
    */
}
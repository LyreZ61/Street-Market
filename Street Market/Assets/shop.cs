using UnityEngine;

public class Shop : MonoBehaviour
{

    public BuildBluePrint standardTurret;
    public BuildBluePrint missileLauncher;
    public BuildBluePrint laserBeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);          // ohne buy system buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);

    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missle Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);         //ohne buy system buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab); 

    }

    public void SelectLaserBeamer()
    {
        Debug.Log("LaserBeamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);         //ohne buy system buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab); 

    }
}

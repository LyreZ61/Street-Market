using UnityEngine;
using UnityEngine.UI;

public class UIBuy : MonoBehaviour
{

    public GameObject ui;

    public Text upgradeCost;

    private WayPoints target;
    public Button upgradeButton;

    public Text sellAmount;         //verkaufen


    public void SetTarget(WayPoints _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();         //Die normale position ist im Object durch target.GetBUildPostition wird die 

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.buildBluePrint.upgradeCost;   //Updatet den text für cost in upgrade-
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.buildBluePrint.GetSellAmount();         //verkaufen textupdate.

        ui.SetActive(true);
    }                                                           //position auf das object drauf gespawn.



    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectWayPoint();
        Debug.Log("Klick working");
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectWayPoint();
    }

}
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpSellUI : MonoBehaviour {

    public GameObject ui;

    public TextMeshProUGUI upgradeCost;

    private HouseSpawn target;
    public Button upgradeButton;

    public TextMeshProUGUI sellAmount;         //verkaufen


    public void SetTarget(HouseSpawn _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();         //Die normale position ist im Object durch target.GetBUildPostition wird die 

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.houseBlueprint.upgradeCost;   //Updatet den text für cost in upgrade-
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.houseBlueprint.GetSellAmount();         //verkaufen textupdate.

        ui.SetActive(true);
    }                                                           //position auf das object drauf gespawn.



    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeHouse();
        BuildManager.instance.DeselectNode();
        Debug.Log("Klick working");
    }

    public void Sell()
    {
        target.SellHouse();
        BuildManager.instance.DeselectNode();
    }


}

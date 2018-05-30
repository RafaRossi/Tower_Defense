using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
    public GameObject ui;
    public Text cost;
    public Text sell;
    public Button button;

    Node node;

	public void SetNode(Node node)
    {
        this.node = node;
        transform.position = new Vector3(node.transform.position.x, node.transform.position.y, node.transform.position.z+0.5f);
        sell.text = "Sell $" + node.cost/2;
        ui.SetActive(true);

        if (!node.isUpgraded)
        {
            cost.text = "UPGRADE $ " + node.blueprint.upgradecost[node.i];
            button.interactable = true;
        }
        else
        {
            cost.text = "Fully Upgraded";
            button.interactable = false;
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        node.Upgrade();
        node.rend.material.color = node.startcolor;
        BuildManager.instance.node = null;
        Hide();
    }

    public void Sell()
    {
        node.Sell();
        node.rend.material.color = node.startcolor;
        BuildManager.instance.node = null;
        Hide();

    }
}

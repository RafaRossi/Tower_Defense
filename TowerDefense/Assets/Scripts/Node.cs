using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color color, noMoneyColor, selectedColor;
    public GameObject turret;
    public Renderer rend;
    public Color startcolor;
    public TurretBlueprint blueprint;
    public bool isUpgraded = false;
    public int i, cost;

    BuildManager build;

    private void Start()
    {
        build = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        noMoneyColor = new Color32(212, 39, 39, 255);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.instance.CanBuild)
            return;

        if (BuildManager.instance.HasMoney)
            rend.material.color = color;
        else
            rend.material.color = noMoneyColor;
    }

    void OnMouseExit()
    {
        if (build.node == this)
            return;
        rend.material.color = startcolor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;      

        if (turret != null)
        {
            build.SelectNode(this);
            return;
        }

        if (!BuildManager.instance.CanBuild)
            return;

        BuildTurret(build.GetTurret());

    }

    void BuildTurret(TurretBlueprint turret)
    {
        if (PlayerStats.Money < turret.price)
            return;

        PlayerStats.Money -= turret.price;
        cost += turret.price;

        GameObject t = Instantiate(turret.turret, transform.position, Quaternion.identity);
        this.turret = t;

        blueprint = turret;

        GameObject e = Instantiate(build.effectPrefab, transform.position, Quaternion.identity);
        Destroy(e, 3);
    }

    public void Upgrade()
    {
        if (PlayerStats.Money < blueprint.upgradecost[i])
            return;

        PlayerStats.Money -= blueprint.upgradecost[i];
        cost += blueprint.upgradecost[i];

        Destroy(turret);
        GameObject t = Instantiate(blueprint.upgrade[i], transform.position, Quaternion.identity);
        turret = t;

        GameObject e = Instantiate(build.effectPrefab, transform.position, Quaternion.identity);
        Destroy(e, 3);

        i++;
        if (i >= blueprint.upgrade.Length)
            isUpgraded = true;
    }

    public void Sell()
    {
        PlayerStats.Money += cost / 2;

        GameObject e = Instantiate(build.effectPrefab, transform.position, Quaternion.identity);
        Destroy(e, 3);

        Destroy(turret);
        blueprint = null;
    }
}

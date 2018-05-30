using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint normalTurret, lightTurret, heavyTurret;

    public void SelectNormalTurret()
    {
        BuildManager.instance.SetTurretToBuild(normalTurret);
    }
    public void SelectLightTurret()
    {
        BuildManager.instance.SetTurretToBuild(lightTurret);
    }
    public void SelectHeavyTurret()
    {
        BuildManager.instance.SetTurretToBuild(heavyTurret);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    TurretBlueprint turretToBuild;
    public Node node;
    
	void Awake () {
        if (instance != null)
            return;
        instance = this;
	}

    public void SetTurretToBuild(TurretBlueprint blueprint)
    {
        turretToBuild = blueprint;
        if(node!=null)
        node.rend.material.color = node.startcolor;
        node = null;
        nodeUI.Hide();
    }

    public bool CanBuild { get {return turretToBuild != null; }}
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.price; } }
    public GameObject effectPrefab;
    public NodeUI nodeUI;

    public void SelectNode(Node n)
    {
        if (node == n)
        {
            nodeUI.Hide();
            node.rend.material.color = node.startcolor;
            node = null;
            return;
        }

        if(node!=null && node != n)
            node.rend.material.color = node.startcolor;

        node = n;
        node.rend.material.color = node.color;  
        turretToBuild = null;

        nodeUI.SetNode(n);
    }

    public TurretBlueprint GetTurret()
    {
        return turretToBuild;
    }

}

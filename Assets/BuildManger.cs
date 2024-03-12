using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManger : MonoBehaviour
{
    public static BuildManger main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;

    private int selectedTower = 0;

    private void Awake(){
        main = this;
    }

    public GameObject GetSelectedTower(){
        return towerPrefabs[selectedTower];
    }
}

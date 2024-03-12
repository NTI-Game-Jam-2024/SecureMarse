using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;   
    [SerializeField] private Color hoverColor; 
    private GameObject tower; 
    private Color startColor;

    private void Start()
    {
        startColor = sr.color; 
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) return;

        GameObject towerToBuild = BuildManger.main.GetSelectedTower(); // Assuming BuildManager is correctly set up and accessible.
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);

        sr.enabled = false;
    }
}

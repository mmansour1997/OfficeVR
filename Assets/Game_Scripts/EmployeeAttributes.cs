using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.

public class EmployeeAttributes : MonoBehaviour
{
    public static EmployeeAttributes main;
    public string EmployeeName = "";
    public float Speed = 0;
    public float CostPerDay = 0;
    public string EmployeeDescription = "";
    public bool IsBusy = false;
    public List<GameObject> Status;
    public GameObject EmployeePanel;
    public int HiringCost = 0;

    private void Awake()
    {
        main = this;
    }
    void Start()
    {
        //set name
        Status[0].GetComponent<TextMeshPro>().text = EmployeeName;

        //set speed
        Status[1].GetComponent<TextMeshPro>().text = Speed.ToString();

        //set cost per day
        Status[2].GetComponent<TextMeshPro>().text = CostPerDay.ToString() + " $/hr";

        //set description
        Status[3].GetComponent<TextMeshPro>().text = EmployeeDescription;
    }

    public void SetPanelActive(bool flag)
    {
        EmployeePanel.gameObject.SetActive(flag);
    }

}

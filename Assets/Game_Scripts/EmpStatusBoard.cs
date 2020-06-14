using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.

public class EmpStatusBoard : MonoBehaviour
{

    GameObject[] Employeeballs;
    public List<GameObject> Status;

    // Start is called before the first frame update
    void Start()
    {
        Employeeballs = GameObject.FindGameObjectsWithTag("Employee");

        for (int i=0; i < 5; i++)
        {
            string getName = Employeeballs[i].gameObject.GetComponent<EmployeeAttributes>().EmployeeName;
            string getSpeed = Employeeballs[i].gameObject.GetComponent<EmployeeAttributes>().Speed.ToString();
            string getCost =  Employeeballs[i].gameObject.GetComponent<EmployeeAttributes>().CostPerDay.ToString();
            string getdesc = Employeeballs[i].gameObject.GetComponent<EmployeeAttributes>().EmployeeDescription;

            Status[i].transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = getName;
            Status[i].transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = getSpeed;
            Status[i].transform.GetChild(0).transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = getCost + "$/hr";
            Status[i].transform.GetChild(0).transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = getdesc;
        }
    }

    void Update()
    {
        Employeeballs = GameObject.FindGameObjectsWithTag("Employee");

        if (Employeeballs != null)
        {
            for (int i = 0; i < 5; i++)
            {
                string getName = Employeeballs[i].gameObject.GetComponent<EmployeeAttributes>().EmployeeName;
                string getSpeed = Employeeballs[i].gameObject.GetComponent<EmployeeAttributes>().Speed.ToString();
                string getCost = Employeeballs[i].gameObject.GetComponent<EmployeeAttributes>().CostPerDay.ToString();
                string getdesc = Employeeballs[i].gameObject.GetComponent<EmployeeAttributes>().EmployeeDescription;

                Status[i].transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = getName;
                Status[i].transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = getSpeed;
                Status[i].transform.GetChild(0).transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = getCost + "$/hr";
                Status[i].transform.GetChild(0).transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = getdesc;
            }
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
public class HiringPanelScript : MonoBehaviour
{
    public GameObject GameCharacters;
    public List<GameObject> Info;
    // Start is called before the first frame update
    void Start()
    {
        int num_of_chars = GameCharacters.transform.childCount;
        for (int i = 0; i < num_of_chars; i++)
        {
            Info[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text
                = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().EmployeeName;
            Info[i].transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>().text
                = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().Speed.ToString();
            Info[i].transform.GetChild(0).GetChild(6).GetComponent<TextMeshProUGUI>().text
                = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().CostPerDay.ToString() +"$/hr";
            Info[i].transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text
                = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().EmployeeDescription;
            Info[i].transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text
                = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().HiringCost.ToString() + "$";
            Info[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int num_of_chars = GameCharacters.transform.childCount;
        if (GameCharacters != null)
        {
            for (int i = 0; i < num_of_chars; i++)
            {
                Info[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text
                    = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().EmployeeName;
                Info[i].transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>().text
                    = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().Speed.ToString();
                Info[i].transform.GetChild(0).GetChild(6).GetComponent<TextMeshProUGUI>().text
                    = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().CostPerDay.ToString() + "$/hr";
                Info[i].transform.GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text
                    = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().EmployeeDescription;
                Info[i].transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text
                    = GameCharacters.transform.GetChild(i).GetComponent<EmployeeAttributes>().HiringCost.ToString() + "$";
                Info[i].SetActive(true);
            }
        }
    }

}
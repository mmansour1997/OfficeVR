using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireButtonScript : MonoBehaviour
{
    public GameObject GameCharacters;
    public GameObject PlayerTableController;
    public GameObject s;
    public GameObject EmployeePanel;
    public int buttonNumber = 0;
    public void HireEmployee(bool flag)
    {
        string PrefabName = GameCharacters.transform.GetChild(buttonNumber).name;
        Debug.Log("entered");
        GameObject InitEmp = Instantiate(s, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        InitEmp.transform.parent = PlayerTableController.transform;
        InitEmp.transform.localPosition = new Vector3(Random.Range(-0.550f, 0.655f), 1.25f, Random.Range(-0.5f, -0.16f));
        //Destroy(GameCharacters.transform.GetChild(buttonNumber).gameObject, 1);
        //new WaitForSeconds(1);
        GameCharacters.transform.GetChild(buttonNumber).gameObject.SetActive(false);
        EmployeePanel.SetActive(false);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollider : MonoBehaviour
{
    public Material MatGreen;
    public Material MatWhite;
    public GameObject EmployeeObject;
    public GameObject EmployeeTable;
    
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EmployeeBall")
        {
            gameObject.GetComponent<Renderer>().material = MatGreen;
            EmployeeObject = collision.gameObject.transform.GetChild(0).gameObject;


            if (EmployeeTable.name == "Employee1"|| EmployeeTable.name == "Employee2")
            {
                GameObject InitEmp = Instantiate(EmployeeObject, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                InitEmp.transform.parent = EmployeeTable.transform;
                InitEmp.transform.localPosition = new Vector3(0, 0, 0);
                InitEmp.transform.localScale = new Vector3(1.176471f, 1.176471f, 1.176471f);
                InitEmp.transform.Rotate(new Vector3(0, -90, 0));
                InitEmp.GetComponent<AudioSource>().enabled = true;
            }
            else if (EmployeeTable.name == "Employee3")
            {
                GameObject InitEmp = Instantiate(EmployeeObject, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                InitEmp.transform.parent = EmployeeTable.transform;
                InitEmp.transform.localPosition = new Vector3(0, 0, 0);
                InitEmp.transform.localScale = new Vector3(1, 1, 1);
                InitEmp.transform.Rotate(new Vector3(0, 90, 0));
                InitEmp.GetComponent<AudioSource>().enabled = true;
            }
            else if (EmployeeTable.name == "Employee4" || EmployeeTable.name == "Employee5")
            {
                GameObject InitEmp = Instantiate(EmployeeObject, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                InitEmp.transform.parent = EmployeeTable.transform;
                InitEmp.transform.localPosition = new Vector3(0, 0, 0);
                InitEmp.transform.localScale = new Vector3(1.176471f, 1.176471f, 1.176471f);
                InitEmp.GetComponent<AudioSource>().enabled = true;
                //InitEmp.transform.Rotate(new Vector3(0, -90, 0));
            }

        }
        
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "EmployeeBall")
        {
            gameObject.GetComponent<Renderer>().material = MatWhite;
            EmployeeObject = null;
            int num_of_childs = EmployeeTable.transform.childCount;
            for (int i = 0; i < num_of_childs; i++) Destroy(EmployeeTable.transform.GetChild(i).gameObject);
        }
    }

}

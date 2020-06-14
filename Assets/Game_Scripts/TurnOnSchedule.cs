using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
public class TurnOnSchedule : MonoBehaviour
{
    public GameObject Schedule;
    GameObject Ref_schedule;
    float speed = 1f;
    public float AnimationSpeed = 0.1f;
    public bool StartSchedule = false;
    public float TestAnimationSpeed = 0.1f;
    bool finishedAnimation = false;
    bool testFinishedAnimation = false;
    GameObject Station;
    public GameObject CurrentTime;
    List<string> NameEmployees = new List<string>();
    //List<bool> BusyEmployees = new List<bool>();
    public List <GameObject> TaskHolder;
    public GameObject CostBudgetPanel;
    public List<Material> Shaders;
    public GameObject TableLight;
    bool won = false;
    private int revenue = 0;
    public GameObject revenueObject;
    int Cost = 0;
    // Start is called before the first frame update
    void Start()
    {
        //instantiate schedule
        GameObject Start_schedule = Instantiate(Schedule, transform.position, Quaternion.identity) as GameObject;
        Start_schedule.transform.parent = transform;
        Start_schedule.transform.localScale = new Vector3(1, 1, 1);
        Ref_schedule = Start_schedule;

        Station = GameObject.Find("Workstation");
        Debug.Log(CostBudgetPanel.name);
        //CurrentTime = GameObject.Find("CurrentTime");
        //Debug.Log(CurrentTime.name);
        //PlayerScript playerScript = thePlayer.GetComponent<PlayerScript>();



    }


    // Update is called once per frame
    void Update()
    {
        if (speed <= 25)
        {
            //TableLight.SetActive(true);
            AnimateSchedule(speed);
            speed = speed + AnimationSpeed;
            TableLight.GetComponent<Renderer>().material = Shaders[0];
            TableLight.SetActive(true);
        }
        else
        {
            if (!finishedAnimation) AnimateLinks();
        }

        //Debug.Log(Ref_schedule.transform.GetChild(0).name);

        if (StartSchedule)
        {
            if (!testFinishedAnimation && !Station.GetComponent<TableController>().Stop)
            {
                Station.GetComponent<TableController>().TurnOnTime = true;
                BeginTestAnimation();
                Debug.Log(Shaders[1]);

                //TableLight.SetActive(true);
                //Debug.Log(Station.GetComponent<TableController>().Stop);
                //if (Station.GetComponent<TableController>().Stop) testFinishedAnimation = true;

                
            }
            if (won)
            {
                TableLight.GetComponent<Renderer>().material = Shaders[3];
                revenue += IntParseFast(CostBudgetPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text) - Cost;
                revenueObject.GetComponent<TextMeshProUGUI>().text = revenue.ToString();
                won = false;
            }
        }
    }
    bool EnableText = false;
    void AnimateSchedule(float scaler)
    {
        foreach (Transform child in Ref_schedule.transform)
        {

            foreach (Transform child2 in child)
            {
                int tagNumber = IntParseFast(child2.tag);
                if (tagNumber <= 25 && scaler <= tagNumber && child2.name == "Task")
                {
                    child2.transform.localScale = new Vector3(scaler + 0.1f, 1, 1);
                    if ((scaler + 0.1f) >= tagNumber) EnableText = true;

                }
                else if (child2.name == "Text (TMP)" && EnableText)
                {
                    child2.transform.gameObject.SetActive(EnableText);
                    EnableText = false;

                }
                //Debug.Log(scaler);
                
            }
        }
    }

    int num_of_childs = 0;
    void AnimateLinks()
    {
        foreach (Transform child in Ref_schedule.transform)
        {

            if (child.name == "TaskLinks")
            {
                child.GetChild(num_of_childs).gameObject.SetActive(true);
                if (num_of_childs < child.childCount - 1) num_of_childs++;
                else finishedAnimation = true;
            }
        }
    }

    int taskNumber = 0;
    int paraTask = 1;
    bool day_to_start = false;


    void BeginTestAnimation()
    {
        TableLight.GetComponent<Renderer>().material = Shaders[1];
        int num_tasks = Ref_schedule.transform.childCount - 1;
        foreach (Transform child in Ref_schedule.transform)
        {

            int tagNumber = IntParseFast(child.transform.GetChild(0).tag);
            day_to_start = CurrentTime.transform.position.x <= child.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).position.x;
            float scaler = child.transform.GetChild(0).transform.localScale.x;

            
            GameObject Employee = null;
            if (child.name == "Task1") Employee = TaskHolder[0].GetComponent<PipeCollider>().EmployeeObject;
            else if (child.name == "Task2") Employee = TaskHolder[1].GetComponent<PipeCollider>().EmployeeObject;
            else if (child.name == "ParaTask1") Employee = TaskHolder[2].GetComponent<PipeCollider>().EmployeeObject;
            else if (child.name == "ParaTask2") Employee = TaskHolder[3].GetComponent<PipeCollider>().EmployeeObject;
            else if (child.name == "ParaTask3") Employee = TaskHolder[4].GetComponent<PipeCollider>().EmployeeObject;
            else Debug.Log("Error No employee was detected!!!!!!");
            float EmployeeSpeed = Employee.GetComponent<EmployeeAttributes>().Speed;


            if (child.name == "ParaTask" + paraTask)
            {
                if (scaler <= tagNumber * 2)
                {
                    Employee.GetComponent<EmployeeAttributes>().IsBusy = true;
                    float employee_speed = EmployeeSpeed / 10;
                    
                    scaler = child.transform.GetChild(0).transform.localScale.x + employee_speed;
                    child.transform.GetChild(0).transform.localScale = new Vector3(scaler, 1, 1);
                    Cost = Cost + 1;
                    CostBudgetPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = Cost.ToString();
                    if ((scaler) >= tagNumber * 2)
                    {
                        taskNumber++;
                        paraTask++;
                        Employee.GetComponent<EmployeeAttributes>().IsBusy = false;
                    }
                }
            }
            else if (child.name == "Task1" || child.name == "Task2")
            {

                if (scaler <= tagNumber * 2 && day_to_start)
                {

                    Employee.GetComponent<EmployeeAttributes>().IsBusy = true;
                    float employee_speed = EmployeeSpeed / 10;
                    scaler = child.transform.GetChild(0).transform.localScale.x + employee_speed;
                    child.transform.GetChild(0).transform.localScale = new Vector3(scaler, 1, 1);
                    Cost = Cost + 1;
                    CostBudgetPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = Cost.ToString();
                    if ((scaler) >= tagNumber * 2)
                    {
                        taskNumber++;
                        Employee.GetComponent<EmployeeAttributes>().IsBusy = false;
                    }
                }
               
            }

            if (Cost > IntParseFast(CostBudgetPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text))
            {
                TableLight.GetComponent<Renderer>().material = Shaders[2];
                testFinishedAnimation = true;
                Station.GetComponent<TableController>().Stop = true;
            }

            if (taskNumber == num_tasks)
            {
                TableLight.GetComponent<Renderer>().material = Shaders[3];
                testFinishedAnimation = true;
                Station.GetComponent<TableController>().Stop = true;
                won = true;

            }
           

        }
    }


    public static int IntParseFast(string value)
    {
        int result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char letter = value[i];
            result = 10 * result + (letter - 48);
        }
        return result;
    }

    public void StartButton(bool start)
    {
        StartSchedule = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;

public class AccelerometerInput : MonoBehaviour {
    public Text TextOutput;
    public Text Warntext;
	public GameObject WarningMessage;
	public GameObject WarningToggle;

    private float previousX;
    private float previousY;
    private float previousZ;

    private int counter;

    //For filewriting
    private string filePath;

    Gyroscope m_Gyro;
    // Use this for initialization
    void Start() {
        /*
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        */
        counter = 0;

        //For filewriting
        filePath = Application.persistentDataPath + "/MeasuredD-M-h-m" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".csv";
        
    }

    // Update is called once per frame
    void Update()
    {

        counter++;
        
            //Get acceleration change since last frame
            Vector3 acc = Input.acceleration;
            //acc.Normalize();
            float changeX = previousX - acc.x;
            float changeY = previousY - acc.y;
            float changeZ = previousZ - acc.z;
           
		//Don't update the values to fast
        if (counter % 10 == 0)
        {
            TextOutput.text = "X Speed: " + changeX +
                            "\n Y Speed: " + changeY +
                            "\n Z Speed: " + changeZ;
		}
            previousX = acc.x;
            previousY = acc.y;
            previousZ = acc.z;
            //in case of too fast movement (only if WarningToggle is enabled, means warnings can be disabled)
            if (WarningToggle.GetComponent<Toggle>().isOn &&(changeX > 0.09 || changeY > 0.09 || changeZ > 0.09))
            {
                Warntext.text = "Warning";
				WarningMessage.SetActive(true);
            }
            else
            {
                Warntext.text = "";
            }

        


        //Save information into file
        //SaveToFile(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
		/*
		//Show a very annoying message, if tablet was moved to fast
		if(counter > 100 &&(Input.acceleration.x > 0.1 || Input.acceleration.x < -0.2 
		|| Input.acceleration.y > -0.3 || Input.acceleration.y < -0.9
		|| Input.acceleration.z > 0.5 || Input.acceleration.z < -0.9)){
			WarningMessage.SetActive(true);
		}
		*/
    }

    void SaveToFile(float changeX, float changeY, float changeZ)
    {


        string scores = System.DateTime.Now.ToString("HH:mm:ss") + ";" + changeX + ";" + changeY + "; " + changeZ + "\r\n";


        if (!File.Exists(filePath))
             {
            // File.WriteAllText(filePath, scores);

            StreamWriter sr = System.IO.File.CreateText(filePath);
            sr.WriteLine("time;AccelerationChangeX;AccelerationChangeY;AccelerationChangeZ");
            sr.WriteLine(scores);
            sr.Close();

            Debug.Log("Created file at "+ filePath);
            TextOutput.text = "create file " + filePath;
        }
        else{

            File.AppendAllText(filePath, scores);
            
            Debug.Log("appended to file");
            TextOutput.text = "append to file " + filePath;
        }

       
    }

}

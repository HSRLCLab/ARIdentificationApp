using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;

public class AccelerometerInput : MonoBehaviour {
    public Text TextOutput;
    public Text Warntext;


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
        //Don't update the values to fast
        if (counter % 10 == 0)
        {
            //Get acceleration change since last frame
            Vector3 acc = Input.acceleration;
            acc.Normalize();
            float changeX = previousX - acc.x;
            float changeY = previousY - acc.y;
            float changeZ = previousZ - acc.z;
            /*
            float changeX = previousX - Input.acceleration.x;
            float changeY = previousY - Input.acceleration.y;
            float changeZ = previousZ - Input.acceleration.z;
            */

            TextOutput.text = "X Speed: " + changeX +
                            "\n Y Speed: " + changeY +
                            "\n Z Speed: " + changeZ;

            previousX = Input.acceleration.x;
            previousY = Input.acceleration.y;
            previousZ = Input.acceleration.z;
            //in case of too fast movement
            if (changeX > 0.09)
            {
                Warntext.text = "Warning";
            }
            else
            {
                Warntext.text = "";
            }

            //Trying to save information into file
            //SaveToFile(changeX, changeY, changeZ);
            //SaveToFile(acc.x, acc.y, acc.z);
        }


        //Save information into file
        SaveToFile(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);

        //same game with gyroscope
        /*
              //Get acceleration change since last frame
         float changeX = previousX - Input.gyro.rotationRate.x;
         float changeY = previousY - Input.gyro.rotationRate.y;
         float changeZ = previousZ - Input.gyro.rotationRate.z;


         TextOutput.text = "X Speed: " + changeX +
                         "\n Y Speed: " + changeY +
                         "\n Z Speed: " + changeZ;

         previousX = Input.gyro.rotationRate.x;
         previousY = Input.gyro.rotationRate.y;
         previousZ = Input.gyro.rotationRate.z;
        
        TextOutput.text = "X Speed: " + Input.gyro.rotationRate.x +
                       "\n Y Speed: " + Input.gyro.rotationRate.y +
                       "\n Z Speed: " + Input.gyro.rotationRate.z;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //For Toggle and UI stuff
using UnityEngine.SceneManagement; //For SceneManager and stuff

public class MainScene_SwitchSceneOptions : MonoBehaviour {

    public GameObject ScenePanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowScenePanel(Toggle toggleButton) {
        ScenePanel.SetActive(toggleButton.isOn);
    }

    public void ChangeScene(string SceneName) {
        Debug.Log("ChangeScene to " + SceneName);
        if (SceneName == "MainScene")
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
        else
        {
            
            string currentlyActive = SceneManager.GetActiveScene().name;

            Debug.Log("Not main scene to " + currentlyActive);
            if (currentlyActive != "MainScene") {
                SceneManager.UnloadSceneAsync(currentlyActive);
            }
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ChangeScene(int scene_number)
    {
        SceneManager.LoadScene(scene_number);
        Debug.Log(scene_number + "Scene");
    }
}

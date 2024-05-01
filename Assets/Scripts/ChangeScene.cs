using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int scene_number;
    public void Change_Scene()
    {
        SceneManager.LoadScene(scene_number);
    }
}

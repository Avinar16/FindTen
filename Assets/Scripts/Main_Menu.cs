using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public static Main_Menu instance; // Статическая переменная для хранения ссылки на экземпляр
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            // Если instance равно null, присваиваем его и используем текущий объект
            instance = this;
        }
        else if (instance != this)
        {
            // Если уже существует другой экземпляр, уничтожаем текущий объект (дубликат)
            Destroy(gameObject);
        }
    }
}

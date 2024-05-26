using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Sound : MonoBehaviour
{
    public static Main_Menu_Sound instance; // Статическая переменная для хранения ссылки на экземпляр
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            // Если instance равно null, присваиваем его и используем текущий объект
            instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожать текущий объект при загрузке новой сцены
        }
        else if (instance != this)
        {
            // Если уже существует другой экземпляр, уничтожаем текущий объект (дубликат)
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void Restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // перезагрузка сцены

    }

    public void SceneLoad(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene (index);
    }
}

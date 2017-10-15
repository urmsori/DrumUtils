using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GotoScene(int buildingIndex)
    {
        SceneManager.LoadScene(buildingIndex);
    }

    public void GotoScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}

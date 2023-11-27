using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public void loadLevelString(string levelName)
    {
        FadeCanvas.fader.FaderLoadString(levelName);
    }

    public void LoadLevelInt(int levelIndex)
    {
        FadeCanvas.fader.FadeLoadInt(levelIndex);
    }

    public void RestartLevel()
    {
        FadeCanvas.fader.FadeLoadInt(SceneManager.GetActiveScene().buildIndex);
    }
}

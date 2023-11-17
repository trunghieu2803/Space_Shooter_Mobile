using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject LoseScreen;

    void Start()
    {
        EndGameManager.endManager.RegisterPanelController(this);
    }

    public void ActivateWin()
    {
        cGroup.alpha = 1;
        winScreen.SetActive(true);
    }
    public void ActivateLose()
    {
        cGroup.alpha = 1;
        LoseScreen.SetActive(true);
    }


}

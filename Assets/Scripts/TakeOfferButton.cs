using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeOfferButton : MonoBehaviour
{
    [SerializeField] private string _sceneName = "TimeshareScene";
    [SerializeField] private TimeshareBeetle _timeshareBeetle = null;

    // Update is called once per frame
    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnAccept()
    {
        if(_timeshareBeetle){
            _timeshareBeetle._offerAccepted = true;
        }
    }
}

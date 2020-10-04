using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeOfferButton : MonoBehaviour
{
    [SerializeField] private string _sceneName = "TimeshareScene";

    // Update is called once per frame
    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}

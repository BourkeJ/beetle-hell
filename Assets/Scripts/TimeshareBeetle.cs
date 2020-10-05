using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeshareBeetle : MonoBehaviour
{
    [SerializeField] private Text _price = null;
    [SerializeField] private Text _beetleDialogueText = null;
    [SerializeField] private string _beetleDialogue = null;
    [SerializeField] private float _beetleWaitTime = 10f;
    [SerializeField] private string _sceneName = "TimeshareBeetle";

    public bool _hagglePressed = false;
    public bool _offerAccepted = false;

    void Update()
    {
        //reset price when haggle button pressed
        if (_hagglePressed == true){
            float priceNum = Random.Range(1000, 10000000);
            _price.text = priceNum.ToString();
            _hagglePressed = false;
        }

        if(_offerAccepted == true){
            _beetleDialogueText.text = _beetleDialogue;
            _beetleWaitTime -= Time.deltaTime;
            if(_beetleWaitTime <= 0f){
                SceneManager.LoadScene(_sceneName);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeshareBeetle : MonoBehaviour
{
    [SerializeField] private Text _price = null;

    public bool _hagglePressed = false;

    void Update()
    {
        //reset price when haggle button pressed
        if (_hagglePressed == true){
            float priceNum = Random.Range(1000, 10000000);
            _price.text = priceNum.ToString();
            _hagglePressed = false;
        }


    }
}

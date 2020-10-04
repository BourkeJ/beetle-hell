using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaggleButton : MonoBehaviour
{
    [SerializeField] private TimeshareBeetle _timeshareBeetle = null;
    [SerializeField] private RectTransform _barHash = null;
    [SerializeField] private float _clickLeftPos = 0f;
    [SerializeField] private float _clickRightPos = 0f;
    private bool penis = false;

    void Update()
    {
        //_timeshareBeetle._hagglePressed = false;
        if (_barHash.anchoredPosition.x >= _clickLeftPos && _barHash.anchoredPosition.x <= _clickRightPos) 
        {
            penis = true;
        } else{
            penis = false;
        }
    }

    public void OnClick()
    {
        if(penis == true){
            _timeshareBeetle._hagglePressed = true;
            print("yes");
        }
        print("pressed");
    }

}

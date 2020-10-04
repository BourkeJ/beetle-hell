using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaggleButton : MonoBehaviour
{
    [SerializeField] private TimeshareBeetle _timeshareBeetle = null;
    [SerializeField] private RectTransform _barHash = null;
    [SerializeField] private float _clickLeftPos = 0f;
    [SerializeField] private float _clickRightPos = 0f;
    private Button _haggleButton = null;

    void Awake()
    {
        _haggleButton = GetComponent<Button>();
    }

    void Update()
    {
        if (_barHash.anchoredPosition.x >= _clickLeftPos && _barHash.anchoredPosition.x <= _clickRightPos) 
        {
            _haggleButton.interactable = true;
        } else{
            _haggleButton.interactable = false;
        }
    }

    public void OnClick()
    {
        _timeshareBeetle._hagglePressed = true;
        print("yes");
    }

}

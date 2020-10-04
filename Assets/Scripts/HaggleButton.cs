using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaggleButton : MonoBehaviour
{
    [SerializeField] private TimeshareBeetle _timeshareBeetle = null;

    public void OnClick()
    {
        _timeshareBeetle._hagglePressed = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaggleButton : MonoBehaviour
{
    [SerializeField] private TimeshareBeetle _timeshareBeetle = null;
    [SerializeField] private string[] _beetleDialogue = null;
    [SerializeField] private Text _beetleDialogueText = null;

    public void OnClick()
    {
        _timeshareBeetle._hagglePressed = true;
        _beetleDialogueText.text =_beetleDialogue[Random.Range(0, _beetleDialogue.Length)];
    }
}

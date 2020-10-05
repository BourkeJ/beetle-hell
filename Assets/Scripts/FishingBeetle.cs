using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBeetle : MonoBehaviour
{

    [SerializeField] private RectTransform _barHash = null;
    [SerializeField] private float _barLeftPos = 0f;
    [SerializeField] private float _barRightPos = 10f;
    [SerializeField] private float _moveTime = 1f;
    [SerializeField] private float _clickLeftPos = 0f;
    [SerializeField] private float _clickRightPos = 0f;
    [SerializeField] private Animator _slutAnim = null;
    [SerializeField] private float _buttonTime = 1f;
    [SerializeField] private GameObject _buttonText = null;

    private float _barPosY = 0f;
    private bool _atLeft = false;
    private float _movePos = 1f;
    private int _fishIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _barPosY = _barHash.anchoredPosition.y;
        _buttonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // bar hash osccilation
        if(_barLeftPos <= _barHash.anchoredPosition.x + 1f && _barLeftPos >= _barHash.anchoredPosition.x - 1f)
        {
            _atLeft = true;
        }
        if(_barRightPos >= _barHash.anchoredPosition.x - 1f && _barRightPos <= _barHash.anchoredPosition.x + 1f){
            _atLeft = false;
        }

        if(_atLeft == true){
            _movePos += _moveTime * Time.deltaTime;
        }else{
            _movePos -= _moveTime * Time.deltaTime;
        }
        
        _barHash.anchoredPosition = new Vector2 (Mathf.Lerp(_barLeftPos, _barRightPos, _movePos), _barPosY);


        //on click in green, print "pressed", on click outside green, print "goofed"
        if (Input.GetMouseButtonDown(0) && _barHash.anchoredPosition.x >= _clickLeftPos && _barHash.anchoredPosition.x <= _clickRightPos) 
        {
            _slutAnim.SetTrigger("Pressed");
            _fishIndex += 1;
        }else if(Input.GetMouseButtonDown(0) && (_barHash.anchoredPosition.x <= _clickLeftPos || _barHash.anchoredPosition.x >= _clickRightPos)){
            _slutAnim.SetTrigger("Goofed");
            if(_fishIndex -1 >= 0){
                _fishIndex -= 1;
            }
        }

        if (_fishIndex == 3){
            _buttonTime -= Time.deltaTime;
            if(_buttonTime <= 0f){
                _buttonText.SetActive(true);
            }
        }
    }
}

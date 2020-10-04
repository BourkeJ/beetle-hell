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

    private float _barPosY = 0f;
    private bool _atLeft = false;
    private float _movePos = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _barPosY = _barHash.anchoredPosition.y;
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
            print("pressed");
        }else if(Input.GetMouseButtonDown(0) && (_barHash.anchoredPosition.x <= _clickLeftPos || _barHash.anchoredPosition.x >= _clickRightPos)){
            print("goofed");
        }
    }
}

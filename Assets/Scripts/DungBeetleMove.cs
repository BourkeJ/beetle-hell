using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungBeetleMove : MonoBehaviour
{
    private Animator _animator = null;
    private float _barPosY = 0f;
    private bool _atLeft = false;
    private float _movePos = 1f;
    private int _goofIndex = 0;
    private float _doorTimer = 0f;
    [SerializeField] private float _clickLeftPos = 0f;
    [SerializeField] private float _clickRightPos = 0f;

    //private bool _inGreenRight = false;
    //private bool _inGreenLeft = false;

    [SerializeField] private RectTransform _barHash = null;
    [SerializeField] private float _barLeftPos = 0f;
    [SerializeField] private float _barRightPos = 10f;
    [SerializeField] private float _moveTime = 1f;

    //[SerializeField] private float _clickLeftPosTransform = null;
    //[SerializeField] private float _clickRightPosTransform = null;

    [SerializeField] private GameObject _doorGlow = null;
    [SerializeField] private float _doorWaitTime = 0f;
    [SerializeField] private int _maxGoof = 3;

    [SerializeField] private Animator _camAnim = null;
    [SerializeField] private Animator _dadPushAnim = null;
    [SerializeField] private Animator _ballPushAnim = null;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _barPosY = _barHash.anchoredPosition.y;
        _doorGlow.SetActive(false);
        _doorTimer = _doorWaitTime;

        //_clickLeftPos = _clickLeftPosTransform.anchoredPosition.x;
        //_clickRightPos = _clickRightPosTransform.anchoredPosition.x;
    }

    // Update is called once per frame
    void FixedUpdate()
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
    }
    
    void Update()
    {
        //on click, beetle dad moves
        if (Input.GetMouseButtonDown(0) && _barHash.anchoredPosition.x >= _clickLeftPos && _barHash.anchoredPosition.x <= _clickRightPos) 
        {
            _animator.SetTrigger("Pressed");
            _camAnim.SetTrigger("Pressed");
            _dadPushAnim.SetTrigger("Pressed");
            _ballPushAnim.SetTrigger("Pressed");
        }else if(Input.GetMouseButtonDown(0) && (_barHash.anchoredPosition.x <= _clickLeftPos || _barHash.anchoredPosition.x >= _clickRightPos)){
            _animator.SetTrigger("Goofed");
            _camAnim.SetTrigger("Goofed");
            _dadPushAnim.SetTrigger("Goofed");
            _ballPushAnim.SetTrigger("Goofed");
            _goofIndex += 1;
        }

        //if you don't click for three times, beetle boss comes out
        /*if(_barHash.anchoredPosition.x == _clickRightPos){
            _inGreenRight = true;
            print("rightTrue");
        }
        if(_inGreenRight == true && _barHash.anchoredPosition.x == _clickLeftPos){
            if(Input.GetMouseButtonDown(0)){
                _inGreenRight = false;
                print("yes1");
            }
            _goofIndex += 1;
            _inGreenRight = false;
            print(_goofIndex);
        }

        if(_barHash.anchoredPosition.x == _clickLeftPos){
            _inGreenLeft = true;
        }
        if(_inGreenLeft == true && _barHash.anchoredPosition.x == _clickRightPos){
            _goofIndex += 1;
            _inGreenRight = false;
        }*/
        if(_goofIndex >= _maxGoof){

            _doorGlow.SetActive(true);
            _doorTimer -= Time.deltaTime;
            if(_doorTimer <= 0f){
                _goofIndex = 0;
                _doorGlow.SetActive(false);
                _doorTimer = _doorWaitTime;
            }
        }
    }
}

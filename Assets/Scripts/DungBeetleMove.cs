using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungBeetleMove : MonoBehaviour
{
    private Animator _animator = null;
    private float _barPosY = 0f;
    private bool _atLeft = false;
    private float _movePos = 1f;
    private int _goofIndex = 0;
    private float _doorTimer = 0f;
    private float _dadTimer = 0f;
    private float _kidTimer = 0f;
    private int _pressIndex = 0;
    private int _jokeIndex = 0;

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
    [SerializeField] private GameObject _dadDialogue = null;
    [SerializeField] private GameObject _kidDialogue = null;
    [SerializeField] private float _doorWaitTime = 0f;
    [SerializeField] private float _dadWaitTime = 0f;
    [SerializeField] private float _kidWaitTime = 0f;
    [SerializeField] private int _maxGoof = 3;
    [SerializeField] private int _maxPress = 7;
    //[SerializeField] private GameObject _bar = null;

    [SerializeField] private Animator _camAnim = null;
    [SerializeField] private Animator _dadPushAnim = null;
    [SerializeField] private Animator _ballPushAnim = null;

    [SerializeField] private string[] _dadJokes = null;
    [SerializeField] private string[] _dadUSuck = null;
    [SerializeField] private Text _dadText = null;
    [SerializeField] private Text _kidText = null;

    
    
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _barPosY = _barHash.anchoredPosition.y;
        _doorGlow.SetActive(false);
        _doorTimer = _doorWaitTime;
        _dadTimer = _dadWaitTime;
        _kidTimer = _kidWaitTime;

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
        if (Input.GetMouseButtonDown(0) && _barHash.anchoredPosition.x >= _clickLeftPos && _barHash.anchoredPosition.x <= _clickRightPos && _pressIndex < _maxPress) 
        {
            _animator.SetTrigger("Pressed");
            _camAnim.SetTrigger("Pressed");
            _dadPushAnim.SetTrigger("Pressed");
            _ballPushAnim.SetTrigger("Pressed");
            _pressIndex += 1;
            print(_pressIndex);
        }else if(Input.GetMouseButtonDown(0) && (_barHash.anchoredPosition.x <= _clickLeftPos || _barHash.anchoredPosition.x >= _clickRightPos) && _pressIndex < _maxPress){
            _animator.SetTrigger("Goofed");
            _camAnim.SetTrigger("Goofed");
            _dadPushAnim.SetTrigger("Goofed");
            _ballPushAnim.SetTrigger("Goofed");
            _goofIndex += 1;
            _pressIndex -= 1;
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

        if(_pressIndex >= _maxPress){
            _dadText.text = _dadJokes[_jokeIndex];
            _kidText.text = _dadUSuck[_jokeIndex];
            _dadDialogue.SetActive(true);
            //_bar.SetActive(false);
            _dadTimer -= Time.deltaTime;
            if(_dadTimer <= 0f){
                _kidDialogue.SetActive(true);
                _kidTimer -= Time.deltaTime;
                if(_kidTimer <= 0f){
                    _pressIndex = 0;
                    _dadDialogue.SetActive(false);
                    _kidDialogue.SetActive(false);
                    _dadPushAnim.SetTrigger("Goofed");
                    _ballPushAnim.SetTrigger("Goofed");
                    //_bar.SetActive(true);
                    _camAnim.SetTrigger("Done");
                    _animator.SetTrigger("Done");
                    if(_jokeIndex < _dadJokes.Length - 1){
                        _jokeIndex += 1;
                    }else{
                        _jokeIndex = 0;
                    }
                    _dadTimer = _dadWaitTime;
                    _kidTimer = _kidWaitTime;
                }
            }
        }
    }
}

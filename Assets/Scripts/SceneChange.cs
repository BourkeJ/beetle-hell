using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private Camera _camera = null;
    [SerializeField] private string _sceneName = "TimeshareScene";

    private Collider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
			Collider2D poster = Physics2D.OverlapPoint(mousePosition);
            if(poster == _collider){
                SceneManager.LoadScene(_sceneName);
            }
        }
    }
}

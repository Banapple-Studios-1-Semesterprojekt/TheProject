using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] FenceBehaviour _fenceBehaviour;

    [SerializeField] bool _isDoorOpenSwitch;
    [SerializeField] bool _isDoorCloseSwitch;

    float _switchSizeY;
    Vector3 _switchUpPos;
    Vector3 _switchDownPos;
    float _switchSpeed = 1f;
    float _switchDelay = 0.2f;
    bool _isPressingSwitch = false; //checks wether or not the switch has been pressed

    // Start is called before the first frame update
    void Awake()
    {
        _switchSizeY = transform.localScale.y / 2; //half size of the switch

        _switchUpPos = transform.position;
        _switchDownPos = new Vector3(transform.position.x,
            transform.position.y - _switchSizeY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else if (!_isPressingSwitch)
        {
            MoveSwitchUp();
        }
    }

    void MoveSwitchDown()
    {
        if(transform.position != _switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _switchDownPos, _switchSpeed * Time.deltaTime);
        }
    }

    void MoveSwitchUp()
    {
        if (transform.position != _switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _switchUpPos, _switchSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dog"))
        {
            _isPressingSwitch = !_isPressingSwitch;

            if (_isDoorOpenSwitch && !_fenceBehaviour._isDoorOpen)
            {
                _fenceBehaviour._isDoorOpen = !_fenceBehaviour._isDoorOpen;
            }
            else if (_isDoorCloseSwitch && !_fenceBehaviour._isDoorOpen)
            {
                _fenceBehaviour._isDoorOpen = !_fenceBehaviour._isDoorOpen;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("dog"))
        {
            StartCoroutine(SwitchUpDelay(_switchDelay));
        }
    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isPressingSwitch = false;
    }
}


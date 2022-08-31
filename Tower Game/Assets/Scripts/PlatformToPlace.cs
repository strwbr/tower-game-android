using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformToPlace : MonoBehaviour
{
    [SerializeField] private float startSpeed = 0.1f;
    [SerializeField] private float speedMultiplaier = 1f;
    [SerializeField] private GameObject allPlatforms;
    [SerializeField] private GameObject platformToCreate;

    public static event Action<Vector3> ActionPlatformAdded;

    private Vector3 _nextPoint;
    private Vector3 _leftBoudaryPos = new Vector3(-20, 1f, 0); // startPos
    private Vector3 _rightBoundaryPos = new Vector3(20, 1f, 0); // endPos
    private bool _isMove = true;
    private bool _isMoveRight;

    private void Start()
    {
        transform.position = _leftBoudaryPos;
        _isMoveRight = true;
    }

    private void Update()
    {
        MovePlatform();

        if (Input.GetMouseButtonDown(0))
        {
            StopPlatform();

            CreateNewPlatform();

            UpdatePlatformPositions();

            startSpeed *= speedMultiplaier;
            _isMoveRight = !_isMoveRight;
            _isMove = true;
        }

        if (IsBoundaryPosition(transform.position))
        {
            startSpeed *= -1f;
        }
    }

    private void MovePlatform()
    {
        if (_isMove)
        {
            _nextPoint = Vector3.right * startSpeed * Time.fixedDeltaTime;
            transform.position += _nextPoint;
        }
    }

    private void StopPlatform()
    {
        _isMove = false;
    }

    private void UpdatePlatformPositions()
    {
        _leftBoudaryPos = new Vector3(_leftBoudaryPos.x, _leftBoudaryPos.y + 1, _leftBoudaryPos.z);
        _rightBoundaryPos = new Vector3(_rightBoundaryPos.x, _rightBoundaryPos.y + 1, _rightBoundaryPos.z);

        transform.position = (_isMoveRight) ? _rightBoundaryPos : _leftBoudaryPos;
    }

    private bool IsBoundaryPosition(Vector3 pos)
    {
        bool isRightBoundary = pos.x >= _rightBoundaryPos.x && startSpeed > 0f;
        bool isLeftBoundary = pos.x <= _leftBoudaryPos.x && startSpeed < 0f;
        return isRightBoundary || isLeftBoundary;
    }

    private void CreateNewPlatform()
    {
        Vector3 currentPosition = transform.position;

        Vector3 positionToCreate = new Vector3(
            Convert.ToSingle(Mathf.Round(currentPosition.x)),
            currentPosition.y,
            currentPosition.z);

        //Quaternion quaternion = new Quaternion();
        //    quaternion.SetLookRotation(Vector3.zero);

        GameObject newPlatform = Instantiate(platformToCreate, positionToCreate, Quaternion.identity) as GameObject;
        newPlatform.transform.SetParent(allPlatforms.transform);

        ActionPlatformAdded?.Invoke(newPlatform.transform.position);
    }
}

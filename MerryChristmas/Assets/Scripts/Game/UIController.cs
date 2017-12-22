using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController: MonoBehaviour
{
    public float speed = 1f;
    public Vector3 rotAmount = new Vector3(90, 0, 0);
    [SerializeField] private GameObject _card;

    Quaternion _startRot;

    public void Init()
    {
        _startRot = _card.transform.rotation;
    }

    public void Reset()
    {
        _card.transform.rotation = _startRot;
        _card.gameObject.SetActive(true);
    }

    public void StartButtonPressed()
    {
        StartCoroutine(RotateY());
    }

    private IEnumerator RotateY()
    {
        var oldRotation = _card.transform.rotation;
        _card.transform.Rotate(0, 90, 0);
        var newRotation = _card.transform.rotation;

        for (var t = 0.0f; t <= 1.0f; t += Time.deltaTime)
        {
            _card.transform.rotation = Quaternion.Slerp(oldRotation, newRotation, t);
            yield return null;
        }
        _card.transform.rotation = newRotation;
        _card.gameObject.SetActive(false);

    }
}

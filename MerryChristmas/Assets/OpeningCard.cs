using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCard : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 rotAmount = new Vector3(90, 0, 0);
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject Card;

    public void StartButtonPressed()
    {
        StartCoroutine(RotateY());
    }

    private IEnumerator RotateY()
    {
        var oldRotation = Card.transform.rotation;
        Card.transform.Rotate(0, 90, 0);
        var newRotation = Card.transform.rotation;

        for (var t = 0.0f; t <= 1.0f; t += Time.deltaTime)
        {
            Card.transform.rotation = Quaternion.Slerp(oldRotation, newRotation, t);
            //Button.transform.rotation = Quaternion.Slerp(oldRotation, newRotation, t);
            yield return null;
        }
        Card.transform.rotation = newRotation;
        Button.transform.rotation = newRotation;

    }
}

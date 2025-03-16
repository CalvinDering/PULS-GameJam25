using System.Collections;
using UnityEngine;

public class RotateLoop : MonoBehaviour {

    [SerializeField] private float rotationAngle = 5f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float cooldown = 50f;

    private float startAngle = 0f;

    private bool rotatingForwards = true;

    private void Start() {
        startAngle = transform.eulerAngles.y;
        StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject() {

        while(true) {
            float targetAngle = rotatingForwards ? startAngle + rotationAngle : startAngle - rotationAngle;
            float currentAngle = transform.eulerAngles.y;
            if(currentAngle > 180) {
                currentAngle -= 360;
            }

            float timeToRotate = Mathf.Abs(targetAngle - currentAngle) / rotationSpeed;

            float timeElapsed = 0f;
            while(timeElapsed < timeToRotate) {
                float newAngle = Mathf.Lerp(currentAngle, targetAngle, timeElapsed / timeToRotate);
                transform.localRotation = Quaternion.Euler(0f, newAngle, 0f);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            yield return new WaitForSeconds(cooldown);

            rotatingForwards = !rotatingForwards;

        }

    }

}

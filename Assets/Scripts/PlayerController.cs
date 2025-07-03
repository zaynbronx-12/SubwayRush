using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 5f;

    private int desiredLane = 1;

    void Update() {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow)) desiredLane = Mathf.Max(0, desiredLane - 1);
        if (Input.GetKeyDown(KeyCode.RightArrow)) desiredLane = Mathf.Min(2, desiredLane + 1);

        Vector3 targetPos = transform.position.z * Vector3.forward;
        if (desiredLane == 0) targetPos += Vector3.left * laneDistance;
        if (desiredLane == 2) targetPos += Vector3.right * laneDistance;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * laneChangeSpeed);
    }

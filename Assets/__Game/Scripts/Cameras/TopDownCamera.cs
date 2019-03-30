using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    #region Fields
    public float zoomDampTime = 0.2f;
    public float moveDampTime = 0.2f;
    public float screenEdgePadding = 4f;
    public float minOrthoSize = 6.5f;

    private Camera camera;
    private float refZoomSpeed;
    private Vector3 refMoveVelocity;
    private Vector3 targetPosition;
    #endregion Fields

    #region Unity methods
    private void Start()
    {
        camera = GameManager.Instance.gameCamera;
        SetStartPositionAndSize();
    }

    private void LateUpdate()
    {
        Transform[] targets;
        GameManager.Instance.GetActivePlayers(out targets);

        CalculateTargetPosition(targets);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref refMoveVelocity, moveDampTime);

        Zoom(targets);
    }
    #endregion Unity methods

    private void CalculateTargetPosition(Transform[] targets)
    {
        Vector3 averagePosition = Vector3.zero;

        if (targets.Length > 0)
        {
            foreach (var target in targets)
            {
                averagePosition += target.position;
            }
            averagePosition /= targets.Length;
        }

        averagePosition.y = transform.position.y;
        targetPosition = averagePosition;
    }

    private void Zoom(Transform[] targets)
    {
        float requiredSize = FindRequiredSize(targets);
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, requiredSize, ref refZoomSpeed, zoomDampTime);
    }

    private float FindRequiredSize(Transform[] targets)
    {
        Vector3 localTargetPosition = transform.InverseTransformPoint(targetPosition);
        float cameraSize = 0f;

        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 targetLocalPosition = transform.InverseTransformPoint(targets[i].position);
            Vector3 targetPositionOffset = targetLocalPosition - localTargetPosition;

            cameraSize = Mathf.Max(cameraSize, Mathf.Abs(targetPositionOffset.y));
            cameraSize = Mathf.Max(cameraSize, Mathf.Abs(targetPositionOffset.x) / camera.aspect);
        }

        cameraSize += screenEdgePadding;
        cameraSize = Mathf.Max(cameraSize, minOrthoSize);

        return cameraSize;
    }

    public void SetStartPositionAndSize()
    {
        Transform[] targets;
        GameManager.Instance.GetActivePlayers(out targets);

        CalculateTargetPosition(targets);

        transform.position = targetPosition;
        camera.orthographicSize = FindRequiredSize(targets);
    }
}

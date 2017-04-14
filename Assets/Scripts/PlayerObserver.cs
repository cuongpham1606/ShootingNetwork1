using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class PlayerObserver : MonoBehaviour {
    Player player;

    void Start()
    {
        player = GetComponent<Player>();

    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.currentPosition, 0.1f);
        AimObserver();
    }

    private void AimObserver()
    {
        Vector2 direction = (Vector2)player.currentCursorPos - (Vector2)player.gunTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        player.gunTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (angle > 360) angle -= 360;
        if (angle < 0) angle += 360;
        if (angle > 90 && angle < 270) player.bodyTransform.localScale = new Vector3(-1, 1, 1);
        else player.bodyTransform.localScale = Vector3.one;
    }
}

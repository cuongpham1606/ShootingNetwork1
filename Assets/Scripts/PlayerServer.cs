using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class PlayerServer : MonoBehaviour {
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    public void UpdatePosition(Vector3 position)
    {
        player.currentPosition = position;
    }

    public void UpdateCursorPosition(Vector3 cursorPosition)
    {
        player.currentCursorPos = cursorPosition;
    }
}

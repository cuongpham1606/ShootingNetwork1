using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent (typeof(Collider2D))]
[RequireComponent (typeof (Controller2D))]
public class Player : NetworkBehaviour {
    [SyncVar] public Vector3 currentPosition;
    [SyncVar] public Vector3 currentCursorPos;

    PlayerClient client;
    PlayerServer server;
    PlayerObserver observer;

    public float moveSpeed = 6;
    public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
    public float shootCooldownTime = .5f;

    public Transform bodyTransform;
    public Transform gunTransform;
    public Transform gunPointTransform;
    public LayerMask platformLayerMask;
    public LayerMask playerLayerMask;


    Vector2 cursorPos;
    public float accelerationTimeAirborne = .2f;
	public float accelerationTimeGrounded = .1f;

    public InputManager inputManager;


	void Start() {
        if (isLocalPlayer)
        {
            client = gameObject.AddComponent<PlayerClient>();
        }
        else
        {
			observer = gameObject.AddComponent<PlayerObserver> ();
		}
        if (isServer)
        {
            server = gameObject.AddComponent<PlayerServer>();
        }
    }

    [Command]
    public void CmdChangePosition(Vector3 position)
    {
        server.UpdatePosition(position);
    }

    [Command]
    public void CmdChangeCursorPosition(Vector3 cursorPos)
    {
        server.UpdateCursorPosition(cursorPos);
    }

}

using System.Collections;
using UnityEngine;
using Character;

public class ExternalDevicesInputReader : IEntityInputSource
{
    public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
    public bool Jump { get; private set; }

    public void OnUpdate()
    {
        if (Input.GetButtonDown("Jump"))
            Jump = true;
    }

    public void ResetOneTimeAction()
    {
        Jump = false;
    }
}

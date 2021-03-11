using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CamHandler : MonoBehaviour
{
    public Transform PLAYER;
    void Update()
    {
        this.gameObject.transform.position = PLAYER.transform.position;
    }
}

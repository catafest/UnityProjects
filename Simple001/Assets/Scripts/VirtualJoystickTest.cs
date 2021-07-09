using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystickTest : MonoBehaviour
{
    [SerializeField] private VirtualJoystick inputSource;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = inputSource.Direction;
    }
}

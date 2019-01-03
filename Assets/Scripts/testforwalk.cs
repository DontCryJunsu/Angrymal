using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testforwalk : MonoBehaviour {
    public enum a_state {
        walk=0

    }
    public Animator ani;
    public a_state state = a_state.walk;
    public float speed = 1.0f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        if (ani != null) {
            ani.SetInteger("a_state", (int)state);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed = 5f;
    public LayerMask obstacleLayers;
    public Transform movePoint;
    public Animator anim;

    void Start() {
        movePoint.parent = null;
        body = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f){
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f),.2f,obstacleLayers)){
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"),0f);
                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f){
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical")),.2f,obstacleLayers)){
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"));
                }
            }
        }
    }
}

using System.Collections;
using UnityEngine;

public class LerpzAnimation : MonoBehaviour {
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Run", false);
        }
        else if (Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }
        else if (Input.GetKeyDown("w") || Input.GetKeyDown("s"))
            animator.SetBool("Walk", true);

        if (Input.GetKeyDown("z"))
            animator.SetBool("Kick", true);
        else if (Input.GetKeyUp("z"))
            animator.SetBool("Kick", false);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator panel_anim;
    private float speed = 10.0F;
    private float rotationSpeed = 100.0F;
    private Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        m_Animator.SetFloat("MovX", Input.GetAxis("Vertical"));
        m_Animator.SetFloat("MovY", Input.GetAxis("Horizontal"));

        if (Input.GetMouseButtonDown(1))
        {
            m_Animator.SetBool("isAtt", true);
            panel_anim.Play("PanelFadeOut");
            StartCoroutine(WaitForAnimationAndLoadScene());
        }
    }

    private IEnumerator WaitForAnimationAndLoadScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Death");
    }
}

using UnityEngine;
using System.Collections;

public class Animation_fauteuil_roulant : MonoBehaviour
{
    [SerializeField] private Animation anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animation>();

        //anim.WrapMode = WrapMode.Loop;
        anim.Play("ElleRoule");
    }
}

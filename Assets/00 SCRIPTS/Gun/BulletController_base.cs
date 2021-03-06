using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletController_base : MonoBehaviour
{
    [SerializeField]
    protected float Speed, Damage, LifeTime;

    [SerializeField] Vector3 Movement;

    [SerializeField]
    protected Rigidbody2D rb;

    [SerializeField]
    SpriteRenderer Sprite;

    Coroutine Cor_Deactive;

    protected void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Cor_Deactive = StartCoroutine(Deactive());
    }

    

    private void OnDisable()
    {
        this.rb.velocity = Vector2.zero;
        StopCoroutine(Cor_Deactive);
    }

    public void SetMovement(Vector3 way)
    {
        if (way.x < 0)
            this.Sprite.flipX = true;
        else
            this.Sprite.flipX = false;
        Movement = way;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        this.rb.velocity = Movement * Speed * Time.deltaTime;
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(LifeTime);
        this.gameObject.SetActive(false);
    }
}

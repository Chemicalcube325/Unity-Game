using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Sound effect
    [SerializeField] AudioSource deathSoundEffect;
    [SerializeField] private float damage;
    [SerializeField] private float startingHealth;

    private Animator anim1;
    private Rigidbody2D rb;

    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim1 = GetComponent<Animator>();
    }
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                dead = true;
                Debug.Log("Player died!"); 
                Die();
            }
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void Restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


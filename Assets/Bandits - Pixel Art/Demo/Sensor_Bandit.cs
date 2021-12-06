using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sensor_Bandit : MonoBehaviour {

    private int m_ColCount = 0;

    private float m_DisableTimer;
    public GameObject enemy;

    private Animator anim;
    public Slider EnemyLife;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        m_ColCount = 0;
    }

    public bool State()
    {
        if (m_DisableTimer > 0)
            return false;
        return m_ColCount > 0;
    }

    void OnTriggerEnter(Collider other)
    {
        anim.Play("Attack");
        m_ColCount++;
        if (other.tag == "Player")
        {
            anim.SetBool("Hurt", true);
            EnemyLife.value--;
            if (EnemyLife.value == 0)
            {
                anim.SetBool("Death", true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        m_ColCount--;
    }

    void Update()
    {
        StartCoroutine(CounterLife());
        m_DisableTimer -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        m_DisableTimer = duration;
    }

    IEnumerator CounterLife()
    {
        if (EnemyLife.value == 0)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("GameOver");
            Destroy(enemy);
        }

    }
}

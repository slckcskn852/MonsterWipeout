using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Health : MonoBehaviour
{
	[SerializeField]
	public float startingHealth = 5;
    
    [SerializeField]
    public float currentHealth;
    [SerializeField]
    private GameObject player;
    public bool isDead=false;
    [SerializeField]
    public HealthBar hp;

	private void OnEnable()
	{
		currentHealth = startingHealth;
	}

	public void TakeDamage(int damageAmount)
	{
		currentHealth -= damageAmount;

        if (gameObject.GetComponentInParent<PlayerMovement>())
        {
            hp.SetSize(currentHealth/startingHealth);
        }
		if (currentHealth <= 0)
			Die();
	}

	private void Die()
	{
        isDead=true;
        var temp1 = gameObject.GetComponent<Enemy>();
        var temp2 = gameObject.GetComponentInParent<Enemy>();
        if (temp1||temp2)
        {
            Debug.Log("1");
            gameObject.GetComponent<NavMeshAgent>().Stop();
            StartCoroutine(EnemyDyingAnimation(gameObject.GetComponentInChildren<Animator>()));
        }
        else
        {
            Debug.Log("2");
            StartCoroutine(PlayerDyingAnimation(player.GetComponentInChildren<Animator>()));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
            PlayerPrefs.SetInt("killCount", player.GetComponent<PlayerMovement>().killCount);
        }
	}
    private IEnumerator EnemyDyingAnimation(Animator anim){
        anim.Play("dying");
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //anim.Play("Motion");
        anim.Play("dying");
        //gameObject.SetActive(false);
        Destroy(gameObject);
        player.GetComponent<PlayerMovement>().killCount+=1;

    }
    private IEnumerator PlayerDyingAnimation(Animator anim){
        anim.Play("dying");
        yield return new WaitForSecondsRealtime(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        anim.Play("dying");
        player.SetActive(false);
    }
}
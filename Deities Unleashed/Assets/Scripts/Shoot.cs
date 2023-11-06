using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public CrossBowController crossBowController;

    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;    
    public Button attackButton;
    public AudioSource ShootSound;
    public bool isOnCooldown = false;
    public float cooldownDuration = 2.0f;

    [SerializeField] float arrowSpeed = 30;

    private bool canShoot = true;

    void Start()
    {
        // Find the AttackButton by its name and attach the ShootArrow method to its click event
        ShootSound = GetComponent<AudioSource>();
        attackButton = GameObject.Find("AttackBtn").GetComponent<Button>();
        attackButton.onClick.AddListener(OnAttackButtonClick);

        crossBowController = GetComponentInChildren<CrossBowController>(); // Assuming you have a SpriteRenderer on your Crossbow object
        UpdateButtonIcon();

    }

    public void OnAttackButtonClick()
    {
        if (canShoot && !isOnCooldown)
        {
            ShootArrow();
            StartCoroutine(StartCooldown());
        }
    }

    // Update is called once per frame
    public void ShootArrow()
    {
        ShootSound.Play();
        var arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        arrow.GetComponent<Rigidbody>().velocity = arrowSpawnPoint.forward * arrowSpeed;
    }

    public IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isOnCooldown = false;
    }

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }

    public void UpdateButtonIcon()
    {
        crossBowController.SetCrossBowState(canShoot, isOnCooldown);

    }
}

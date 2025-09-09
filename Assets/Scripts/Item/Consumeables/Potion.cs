using System.Collections;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] public int HealingAmount = 5;
    public string Name = "Health Potion";
    [SerializeField]  public int Quantity = 2;
    [SerializeField] GameObject player;
    [SerializeField] PlayerHealth playerHealth;
    private bool IsReplenishingPotion = false;

    Time potionUsed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {
        HealingAmount = 5;
        Name = "Health Potion";
        Quantity = 2;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Quantity > 0)
        {
            Use();
        }
    }

    public void Use()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player object not found!");
            return;
        }

        playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth component not found on Player object!");
            return;
        }

        int currentHP = playerHealth.currentHP;
        int maxHP = playerHealth.maxHP;

        if (currentHP == maxHP)
        {
            Debug.Log("You are already at full health!");
            return;
        }

        if (currentHP + HealingAmount >= maxHP)
        {
            playerHealth.currentHP = maxHP;
            Debug.Log("You have been healed to full health!");
        }
        else
        {
            playerHealth.currentHP += HealingAmount;
            Debug.Log("You have been healed by " + HealingAmount + " points!");
        }

        Quantity--;

        if (!IsReplenishingPotion)
        {
            StartCoroutine(ReplenishPotion());
        }
    }

    IEnumerator ReplenishPotion()
    {
        IsReplenishingPotion = true;
        while (Quantity < 2)
        {
                yield return new WaitForSeconds(30f);
                Quantity++;
                Debug.Log("Potion replenished! Current quantity: " + Quantity);
        }
        IsReplenishingPotion = false;
    }
}

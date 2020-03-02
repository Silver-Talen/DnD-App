using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] int m_d4Count = 0;
    [SerializeField] int m_d6Count = 0;
    [SerializeField] int m_d8Count = 0;
    [SerializeField] int m_d10Count = 0;
    [SerializeField] int m_d12Count = 0;
    [SerializeField] int m_d20Count = 0;
    [SerializeField] int m_d100Count = 0;
    [SerializeField] int m_dCustomeCount = 0;

    [SerializeField] int m_dCustomeNumber = 0;

    [SerializeField] GameObject m_d4Die;
    [SerializeField] GameObject m_d6Die;
    [SerializeField] GameObject m_d8Die;
    [SerializeField] GameObject m_d10Die;
    [SerializeField] GameObject m_d12Die;
    [SerializeField] GameObject m_d20Die;
    [SerializeField] GameObject m_d100Die;

    bool m_areRolling = false;
    List<GameObject> m_dice;

    private void Start()
    {
        RoleDice();
    }

    private void Update()
    {
        if (m_areRolling)
        {

        }
    }

    public void SpawnDice()
    {
        for(int f = 0; f < m_d4Count; f++)
        {
            GameObject go = Instantiate(m_d4Die);
            go.GetComponent<DiceInfo>().StartRoll(this.transform.position, 6);
            go.transform.localRotation = new Quaternion(Random.value, Random.value, Random.value, Random.value);
            go.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.value, Random.value, Random.value);
            //go.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f) * (1 / GetDiceTotal());

            m_dice.Add(go);
        }
    }

    public void RoleDice()
    {
        m_areRolling = true;

        SpawnDice();
    }

    public int GetDiceTotal(bool includeCustome = false)
    {
        int total = 0;
        total += m_d4Count;
        total += m_d6Count;
        total += m_d8Count;
        total += m_d10Count;
        total += m_d12Count;
        total += m_d20Count;
        total += m_d100Count;
        if (includeCustome) total += m_dCustomeCount;

        return total;
    }

    public void AddDie(string die)
    {
        die = die.ToLower();
        switch (die)
        {
            case "d4":
                m_d4Count++;
                break;
            case "d6":
                m_d6Count++;
                break;
            case "d8":
                m_d8Count++;
                break;
            case "d10":
                m_d10Count++;
                break;
            case "d12":
                m_d12Count++;
                break;
            case "d20":
                m_d20Count++;
                break;
            case "d100":
                m_d100Count++;
                break;
            case "dc":
                m_dCustomeCount++;
                break;

            default:
                break;
        }
    }

    public void RemoveDie(string die)
    {
        die = die.ToLower();
        switch (die)
        {
            case "d4":
                m_d4Count--;
                if (m_d4Count < 0) m_d4Count = 0;
                break;
            case "d6":
                m_d6Count--;
                if (m_d6Count < 0) m_d6Count = 0;
                break;
            case "d8":
                m_d8Count--;
                if (m_d8Count < 0) m_d8Count = 0;
                break;
            case "d10":
                m_d10Count--;
                if (m_d10Count < 0) m_d10Count = 0;
                break;
            case "d12":
                m_d12Count--;
                if (m_d12Count < 0) m_d12Count = 0;
                break;
            case "d20":
                m_d20Count--;
                if (m_d20Count < 0) m_d20Count = 0;
                break;
            case "d100":
                m_d100Count--;
                if (m_d100Count < 0) m_d100Count = 0;
                break;
            case "dc":
                m_dCustomeCount--;
                if (m_dCustomeCount < 0) m_dCustomeCount = 0;
                break;

            default:
                break;
        }
    }

    public void SetCustomeNumber(string num)
    {
        m_dCustomeNumber = int.Parse(num);
    }
}

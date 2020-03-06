using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] GameObject m_canvasDiceOptions;
    [SerializeField] GameObject m_canvasDiceRolling;

    [SerializeField] GameObject m_d4Die;
    [SerializeField] GameObject m_d6Die;
    [SerializeField] GameObject m_d8Die;
    [SerializeField] GameObject m_d10Die;
    [SerializeField] GameObject m_d12Die;
    [SerializeField] GameObject m_d20Die;

    [SerializeField] GameObject m_d4TextGO;
    [SerializeField] GameObject m_d6TextGO;
    [SerializeField] GameObject m_d8TextGO;
    [SerializeField] GameObject m_d10TextGO;
    [SerializeField] GameObject m_d12TextGO;
    [SerializeField] GameObject m_d20TextGO;

    int m_d4Count = 0;
    int m_d6Count = 0;
    int m_d8Count = 0;
    int m_d10Count = 0;
    int m_d12Count = 0;
    int m_d20Count = 0;

    bool m_areRolling = false;
    List<GameObject> m_dice = new List<GameObject>();

    float rollingCheckDellay = 0.5f;
    float rollingCheckTick = 1.0f;

    float diceSSR = 6.0f;

    private void Update()
    {
        if (m_areRolling)
        {
            if (rollingCheckTick <= 0.0f)
            {
                rollingCheckTick = rollingCheckDellay;

                m_areRolling = false;
                foreach(GameObject die in m_dice)
                {
                    if (die.transform.position.y < -20.0f) die.transform.position = this.transform.position + (new Vector3(Random.Range(-diceSSR, diceSSR), 0.0f, Random.Range(-diceSSR, diceSSR)));
                    if (die.GetComponent<DiceInfo>().IsRolling()) m_areRolling = true;
                }
            }
            rollingCheckTick -= Time.deltaTime;

            if (!m_areRolling)
            {
                int total = 0;
                int f = 1;
                foreach (GameObject die in m_dice)
                {
                    int topFace = die.GetComponent<DiceInfo>().GetTopFace();

                    total += topFace;
                    Debug.Log("Die " + f + ": " + topFace);
                    f++;
                }
                Debug.Log("Total: " + total);
            }
        }
    }

    public void RoleDice()
    {
        m_areRolling = true;

        m_canvasDiceOptions.SetActive(false);

        SpawnDice();
    }

    public void SpawnDice()
    {
        for (int f = 0; f < m_d4Count; f++)
        {
            GameObject go = Instantiate(m_d4Die);
            go.transform.position = this.transform.position + (new Vector3(Random.Range(-diceSSR, diceSSR), 0.0f, Random.Range(-diceSSR, diceSSR)));
            go.transform.rotation = new Quaternion(Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f));
            go.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f));
            float speed = 10.0f;
            go.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-speed, speed), -5.0f, Random.Range(-speed, speed));

            m_dice.Add(go);
        }
        for (int f = 0; f < m_d6Count; f++)
        {
            GameObject go = Instantiate(m_d6Die);
            go.transform.position = this.transform.position + (new Vector3(Random.Range(-diceSSR, diceSSR), 0.0f, Random.Range(-diceSSR, diceSSR)));
            go.transform.rotation = new Quaternion(Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f));
            go.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f));
            float speed = 10.0f;
            go.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-speed, speed), -5.0f, Random.Range(-speed, speed));

            m_dice.Add(go);
        }
        for (int f = 0; f < m_d8Count; f++)
        {
            GameObject go = Instantiate(m_d8Die);
            go.transform.position = this.transform.position + (new Vector3(Random.Range(-diceSSR, diceSSR), 0.0f, Random.Range(-diceSSR, diceSSR)));
            go.transform.rotation = new Quaternion(Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f));
            go.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f));
            float speed = 10.0f;
            go.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-speed, speed), -5.0f, Random.Range(-speed, speed));

            m_dice.Add(go);
        }
        for (int f = 0; f < m_d10Count; f++)
        {
            GameObject go = Instantiate(m_d10Die);
            go.transform.position = this.transform.position + (new Vector3(Random.Range(-diceSSR, diceSSR), 0.0f, Random.Range(-diceSSR, diceSSR)));
            go.transform.rotation = new Quaternion(Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f));
            go.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f));
            float speed = 10.0f;
            go.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-speed, speed), -5.0f, Random.Range(-speed, speed));

            m_dice.Add(go);
        }
        for (int f = 0; f < m_d12Count; f++)
        {
            GameObject go = Instantiate(m_d12Die);
            go.transform.position = this.transform.position + (new Vector3(Random.Range(-diceSSR, diceSSR), 0.0f, Random.Range(-diceSSR, diceSSR)));
            go.transform.rotation = new Quaternion(Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f));
            go.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f));
            float speed = 10.0f;
            go.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-speed, speed), -5.0f, Random.Range(-speed, speed));

            m_dice.Add(go);
        }
        for (int f = 0; f < m_d20Count; f++)
        {
            GameObject go = Instantiate(m_d20Die);
            go.transform.position = this.transform.position + (new Vector3(Random.Range(-diceSSR, diceSSR), 0.0f, Random.Range(-diceSSR, diceSSR)));
            go.transform.rotation = new Quaternion(Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f));
            go.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f));
            float speed = 10.0f;
            go.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-speed, speed), -5.0f, Random.Range(-speed, speed));

            m_dice.Add(go);
        }
    }

    public int GetTotalDice()
    {
        int total = 0;
        total += m_d4Count;
        total += m_d6Count;
        total += m_d8Count;
        total += m_d10Count;
        total += m_d12Count;
        total += m_d20Count;

        return total;
    }

    public void AddDie(string die)
    {
        die = die.ToLower();
        switch (die)
        {
            case "d4":
                m_d4Count++;
                m_d4TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d4Count;
                break;
            case "d6":
                m_d6Count++;
                m_d6TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d6Count;
                break;
            case "d8":
                m_d8Count++;
                m_d8TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d8Count;
                break;
            case "d10":
                m_d10Count++;
                m_d10TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d10Count;
                break;
            case "d12":
                m_d12Count++;
                m_d12TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d12Count;
                break;
            case "d20":
                m_d20Count++;
                m_d20TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d20Count;
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
                m_d4TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d4Count;
                break;
            case "d6":
                m_d6Count--;
                if (m_d6Count < 0) m_d6Count = 0;
                m_d6TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d6Count;
                break;
            case "d8":
                m_d8Count--;
                if (m_d8Count < 0) m_d8Count = 0;
                m_d8TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d8Count;
                break;
            case "d10":
                m_d10Count--;
                if (m_d10Count < 0) m_d10Count = 0;
                m_d10TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d10Count;
                break;
            case "d12":
                m_d12Count--;
                if (m_d12Count < 0) m_d12Count = 0;
                m_d12TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d12Count;
                break;
            case "d20":
                m_d20Count--;
                if (m_d20Count < 0) m_d20Count = 0;
                m_d20TextGO.GetComponent<TextMeshProUGUI>().text = "" + m_d20Count;
                break;

            default:
                break;
        }
    }
}

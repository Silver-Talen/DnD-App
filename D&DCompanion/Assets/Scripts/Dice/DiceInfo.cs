using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceInfo : MonoBehaviour
{
    [SerializeField] GameObject[] m_facePositions;
    [SerializeField] GameObject m_die;
    bool isRolling = true;

    Vector3 m_pastPosition = new Vector3(0.0f, 0.0f, 0.0f);

    private void Start()
    {
        m_pastPosition = m_die.transform.position;
    }

    float checkDellay = 0.5f;
    float dellayTimer = 0.0f;

    void Update()
    {
        if (dellayTimer <= 0.0f)
        {
            if (m_pastPosition - m_die.transform.position == new Vector3(0.0f, 0.0f, 0.0f))
            {
                isRolling = false;
                Debug.Log("" + GetTopFace());
            }
            else
            {
                isRolling = true;
            }
            m_pastPosition = m_die.transform.position;

            dellayTimer = checkDellay;
        }

        dellayTimer -= Time.deltaTime;
    }

    public int GetTopFace()
    {
        GameObject topGO = m_facePositions[0];
        topGO.transform.position.Set(0.0f, float.MinValue, 0.0f);
        foreach (GameObject go in m_facePositions)
        {
            if (go.transform.position.y > topGO.transform.position.y) topGO = go;
        }

        int face = int.Parse("" + topGO.name[topGO.name.Length - 1]);

        return face;
    }
}

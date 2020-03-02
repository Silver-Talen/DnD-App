using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceInfo : MonoBehaviour
{
    [SerializeField] GameObject[] m_facePositions;
    [SerializeField] GameObject m_die;

    Vector3 m_pastPosition = new Vector3(0.0f, 0.0f, 0.0f);

    public bool IsRolling()
    {
        bool isRolling;
        if (m_pastPosition - m_die.transform.position == new Vector3(0.0f, 0.0f, 0.0f))
        {
            isRolling = false;
        }
        else
        {
            isRolling = true;
        }

        m_pastPosition = m_die.transform.position;

        return isRolling;
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

    public void StartRoll(Vector3 location, float range)
    {
        m_die.transform.position = location + (new Vector3(Random.Range(0.0f, range), 0.0f, Random.Range(0.0f, range)));
    }
}

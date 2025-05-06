using UnityEngine;
using UnityEngine.Events;

namespace SuperPupSystems
{
public class scoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {

    }


}

public class ScoreInfo
{
    public float score;

    public float multiplier;

    public float delta;

    public Vector3? location;

    public ScoreInfo(float _score, float _multiplier, float _delta, Vector3? _location = null)
    {
        score = _score;
        multiplier = _multiplier;
        delta = _delta;
        location = _location;
    }
}
}
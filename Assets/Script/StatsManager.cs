using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    float _health = 100;
    float _hunger = 100;
    float _mood = 100;
    float _intimacy = 100;

    float _hungerDecaySpeed = 0.1f;
    float _moodDecaySpeed = 0.01f;
    float _healthDecaySpeed = 0.01f;

    void Update()
    {
        //bajar stats 
        _hunger -= Time.deltaTime * _hungerDecaySpeed;
        _mood -= Time.deltaTime * _moodDecaySpeed * 0.5f;

        if (_hunger < 30f || _mood < 30f)
        {
            _health -= Time.deltaTime * _healthDecaySpeed;
        }

        _hunger = Mathf.Clamp(_hunger, 0, 100);
        _mood = Mathf.Clamp(_mood, 0, 100);
        _health = Mathf.Clamp(_health, 0, 100);
    }
    public float GetHealth() => _mood;
    public float GetMood() => _mood;
    public float GetIntimacy() => _intimacy;
    public float GetHunger() => _hunger;

    public void AddMood(float value)
    {
        _mood += value;
        _mood = Mathf.Clamp(_mood, 0, 100);
    }

    public void AddIntimacy(float value)
    {
        _intimacy += value;
        _intimacy = Mathf.Clamp(_intimacy, 0, 100);
    }
}

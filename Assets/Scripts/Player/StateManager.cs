using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private GameObject _damageEffect;
    private class TimeState
    {
        public TemporaryState state;
        public float time;
        public TimeState(TemporaryState state, float time)
        {
            this.state = state;
            this.time = time;
        }
    }

    private List<int> _indicesToRemove = new List<int>();
    private List<TimeState> states = new List<TimeState>();
    private bool isTimerStart = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPickable pickUp))
        {
            pickUp.PickUp(this);
        }

        if (collision.TryGetComponent(out DamageObstacles obstacle))
        {
            if (PlayerStats.Instance.Invulnerable)
            {
                CheckAndDeleteStates<TemporaryBooster>();
                return;
            }
            obstacle.DealDamage();
            Instantiate(_damageEffect, collision.ClosestPoint(collision.transform.position), Quaternion.identity);
        }   
    }
    public void TakeState(TemporaryState state)
    {
        //if booster
        if(state is TemporaryBooster)
        {
            CheckAndDeleteStates<TemporaryBooster>();
        }
        //if debuff
        else
        {
            CheckAndDeleteStates<DecelerationDebuff>();
        }
        state.StartAction();
        isTimerStart = true;
        states.Add(new TimeState(state, state.duration));
    }

    private void CheckAndDeleteStates<T>()
    {
        foreach (var targetState in states)
        {
            if (targetState.state is T)
            {
                targetState.state.StopAction();
                states.Remove(targetState);
                return;
            }
        }
    }

    private void FixedUpdate()
    {
        if(!isTimerStart)
        {
            return;
        }

        for (int i = 0; i < states.Count; i++)
        {
            states[i].state.UpdateAction(ref states[i].time);
            if (states[i].time <= 0)
            {
                states[i].state.StopAction();
                _indicesToRemove.Add(i);
            }
        }

        // deleting from list
        for (int i = _indicesToRemove.Count - 1; i >= 0; i--)
        {
            states.RemoveAt(_indicesToRemove[i]);
        }
        _indicesToRemove.Clear();
    }
}

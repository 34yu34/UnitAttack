using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static float _hit_distance = 0.1f;

    public delegate void OnHitDelegate(Unit target, float damage);

    public float _projectile_speed;

    private Vector3 _direction;

    private Unit _target;
    private float _damage;
    private OnHitDelegate _hit_delegate;

    public void Setup(Unit target, Unit attacker)
    {
        _damage = attacker.CalcAttackDamage();
        _hit_delegate = attacker.OnAttackHit;
        _target = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null || _target.IsDead())
        {
            Destroy(gameObject);
        }
        else
        {
            _direction = (_target.transform.position - transform.position);
            move();
            check_hit();
        }
    }

    private void move()
    {
        Vector3 pos = transform.position;
        pos += _direction.normalized * Time.deltaTime * _projectile_speed;
        transform.position = pos;
    }

    private void check_hit()
    {
        if (_direction.sqrMagnitude <= _hit_distance*_hit_distance)
        {
            _target.ReceiveDamage(_damage);
            _hit_delegate.Invoke(_target, _damage);
            Destroy(gameObject);
        }
    }
}

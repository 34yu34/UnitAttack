using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Unit : MonoBehaviour
{
    public UnitStatsController _stats;
    public UnitStateController _states;

    public Path _path;
    public GameSide.UnitSide _side;

    private SphereCollider _range_collider;
    public Projectile _projectile;
    public Sprite _sprite;

    public Rigidbody _rb;
    public List<Unit> _targets;
    public Unit _curr_target;

    private float _attack_timer;

    public void Awake()
    {
        _stats.ResetStats();
        
        setup_rigid_body();
        setup_range();

        _attack_timer = 1 / _stats.AttackSpeed.Value;
    }

    public void setup_side(SpawnerBoard spawner)
    {
        _side = spawner.Player.Side;
        _path = spawner.Path;

    }

    private void setup_rigid_body()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
        _rb.useGravity = false;
    }

    private void setup_range()
    {
        _range_collider = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        _range_collider.isTrigger = true;
        _range_collider.radius = _stats.Range.Value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _states = new UnitStateController(this);
        _stats.Start();
    }

    // Update is called once per frame
    void Update()
    {
        _stats.Update();
        _states.Update();
        UpdateTarget();

        _attack_timer += Time.deltaTime;
    }

    private void UpdateTarget()
    {
        if (_curr_target == null)
        {
            _targets.RemoveAll((u) => u == null);
            if (_targets.Count > 0)
            {
                _curr_target = _targets[0];
            }
        }
    }

    public void ReceiveDamage(float damage)
    {
        _stats.Health.Remove(damage);
        check_alive();
    }

    public float CalcAttackDamage()
    {
        return _stats.Attack.Value;
    }

    public virtual void LaunchAttack()
    {
        if (CanAttack())
        {
            Projectile att = Instantiate(_projectile, transform.position, Quaternion.LookRotation(_curr_target.transform.position - transform.position));
            Rigidbody rb = att.gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            att.Setup(_curr_target, this);
            _attack_timer = 0.0f;
        }
    }

    public bool CanAttack()
    {
        return _curr_target != null && _attack_timer >= (1 / _stats.AttackSpeed.Value);
    }

    public bool InRange(Unit u)
    {
        return (u.transform.position - transform.position).sqrMagnitude <= _stats.Range.Value * _stats.Range.Value;
    }

    // when an auto attack actually hit the player this function will be call
    public virtual void OnAttackHit(Unit target, AttackInfo att)
    {

    }

    // kill the targeted unit 
    public virtual void Kill()
    {
        Destroy(gameObject);
    }

    // return true if the unit is dead
    public virtual bool IsDead()
    {
        return _stats.Health.Value == 0.0f;
    }
    
    // Check if the unit is alive and kill it if its not
    private void check_alive()
    {
        if (IsDead())
        {
            Kill();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit u = other.GetComponent<Unit>();
        AddTarget(u);

    }

    private void OnTriggerExit(Collider other)
    {
        Unit u = other.GetComponent<Unit>();
        RemoveTarget(u);
 
    }

    // Add the unit to the target list if its in the good team
    private void AddTarget(Unit u)
    {
        if (!(u is null))
        {
            if (!_targets.Contains(u) && u._side != this._side)
            {
                _targets.Add(u);
            }
        }
    }

    // remove the units in the target list and stop attacking it
    private void RemoveTarget(Unit u)
    {
        if (!(u is null))
        {
            _targets.Remove(u);
            if (_curr_target == u)
            {
                _curr_target = null;
            }
        }
    }

}

using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              


    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
		Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

		for (int i = 0; i < colliders.Length; i++){
			Rigidbody targetRigibody = colliders [i].GetComponent<Rigidbody> ();
			// check if we found a rigidbody
			if (!targetRigibody) 
				continue;

			targetRigibody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);

			// can use a component to find another component like in the following line
			TankHealth targetHealt = targetRigibody.GetComponent<TankHealth> ();

			if (!targetHealt)
				continue;

			float damage = CalculateDamage (targetRigibody.position);

			targetHealt.TakeDamage (damage); // this function is public so can be access from another object
		}

		// we detach the explosion to the shell, we want to remove he shell without removing the explosion right away
		m_ExplosionParticles.transform.parent = null;
		m_ExplosionParticles.Play ();
		m_ExplosionAudio.Play ();

		// destroy with a delay
		Destroy (m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
		Destroy (gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
		Vector3 explosionToTarget = targetPosition - transform.position;

		float explosionDistance = explosionToTarget.magnitude;

		float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

		float damage = relativeDistance * m_MaxDamage;

		// we don't want damage to be negative
		damage = Mathf.Max (0f, damage);

        return damage;
    }
}
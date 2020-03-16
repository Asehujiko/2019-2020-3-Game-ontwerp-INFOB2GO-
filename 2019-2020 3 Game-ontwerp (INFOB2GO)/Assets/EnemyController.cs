using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //standard objects
    public Rigidbody rigidbody;
    private float maxRange = 500f;
    private float timer;

    //player info
    public List<GameObject> seePoint;
    private PlayerController player;
    private bool seeplayer = false;
    private Vector3 lastPlayerLocation;

    //navigation points
    private NavigationPoint[] navPoints;
    private int currentnavPoint;

    //pathfinding
    public NavMeshAgent agent;
    private NavMeshPath path;
    private Vector3[] currentPath;
    private bool haspath;
    private int pathindex;

    //movement
    private GameObject direction;
    public float movementSpeed = 3f;
    public float rotationSpeed = 3f;
    private bool startRotate = false;

    //targeting
    public float turretRotatorSpeed = 90f;
    public float turretElevetorSpeed = 45f;
    public GameObject turretRotator;
    public GameObject turretElevator;
    private GameObject turretRotation;
    private GameObject turretElevation;

    //weapons
    public EnemyWeaponController weaponController;
    private GameObject shootdirection;
    public LayerMask ignoreLayer;

    private void Start()
    {
        //set values
        haspath = false;
        agent.updatePosition = false;
        agent.updateRotation = false;
        timer = 0;
        currentnavPoint = -1;

        //new objects
        path = new NavMeshPath();
        direction = new GameObject();
        player = FindObjectOfType<PlayerController>();
        navPoints = FindObjectsOfType<NavigationPoint>();
        turretElevation = new GameObject();
        turretRotation = new GameObject();
        shootdirection = new GameObject();
    }

    void Update()
    {
        if (!seeplayer && Timer())
        {
            CheckSeePlayer();
        }

        Path();
        Target();
        Shoot();
    }

    private void Shoot()
    {
        if (!CheckSeePlayer())
        {
            return;
        }

        float targetrotation = Rotation360(turretRotation.transform.eulerAngles.y);
        float ownrotation = Rotation360(turretRotator.transform.localEulerAngles.y);

        if (Mathf.Abs(Rotation360(targetrotation - ownrotation)) < 10)
        {
            Ray ray = new Ray();
            ray.origin = turretElevator.transform.position;
            ray.direction = turretElevator.transform.forward;

            RaycastHit hit;
            Vector3 hitlocation;
            if (Physics.Raycast(ray, out hit, maxRange, ~ignoreLayer))
            {
                hitlocation = hit.point;
            }
            else
            {
                hitlocation = turretElevator.transform.forward * maxRange + turretElevator.transform.position;
            }

            weaponController.Shoot(hitlocation);
        }
    }

    //target the player tank
    private void Target()
    {
        if (!CheckSeePlayer())
        {
            return;
        }

        SetRotator();
        SetElevator();
    }

    private void SetRotator()
    {
        Vector3 target = player.transform.position;
        Vector3 turretlocation = turretRotator.transform.position;
        Quaternion bodyrotation = transform.rotation;
        target = target - turretlocation;
        target = Quaternion.Inverse(bodyrotation) * target;

        turretRotation.transform.position = new Vector3(0, 0, 0);
        turretRotation.transform.LookAt(target);
        float rotation = Rotation360(turretRotation.transform.eulerAngles.y);

        float ownRotation = turretRotator.transform.localEulerAngles.y;

        if (rotation - 180 > ownRotation)
            ownRotation += 360;

        if (rotation + 180 < ownRotation)
            ownRotation -= 360;

        float leftBound = ownRotation - turretRotatorSpeed * Time.deltaTime;
        float rightBound = ownRotation + turretRotatorSpeed * Time.deltaTime;

        turretRotator.transform.localRotation = Quaternion.Euler(0, Mathf.Clamp(rotation, leftBound, rightBound),0);
    }

    private void SetElevator()
    {
        Vector3 target = player.transform.position;
        Vector3 turretlocation = turretElevator.transform.position;
        Quaternion bodyrotation = transform.rotation;
        target = target - turretlocation;
        target = Quaternion.Inverse(bodyrotation) * target;

        turretElevation.transform.position = new Vector3(0, 0, 0);
        turretElevation.transform.LookAt(target);
        float elevation = Rotation360(turretElevation.transform.eulerAngles.x);

        float ownElevation = turretElevator.transform.localEulerAngles.x;

        if (elevation < 135 && elevation > 8)
            elevation = 8;

        if (elevation > 225 && elevation < 330)
            elevation = 330;

        if (elevation - 180 > ownElevation)
            ownElevation += 360;

        if (elevation + 180 < ownElevation)
            ownElevation -= 360;
        float leftBound = ownElevation - turretElevetorSpeed * Time.deltaTime;
        float rightBound = ownElevation + turretElevetorSpeed * Time.deltaTime;

        turretElevator.transform.localRotation = Quaternion.Euler(Mathf.Clamp(elevation, leftBound, rightBound), 0, 0);
    }

    //check for paths and set destinations and move the tank
    private void Path()
    {
        if (seeplayer)
        {
            if (CheckSeePlayer() && Timer())
            {
                Vector3 prevlastPlayerLocation = lastPlayerLocation;
                lastPlayerLocation = player.transform.position;
                if (prevlastPlayerLocation != lastPlayerLocation)
                {
                    SetDestination(lastPlayerLocation);
                }
            }
        }
        else
        {
            if (!haspath || Vector3.Distance(currentPath[currentPath.Length - 1], transform.position) < 2)
            {
                if (navPoints.Length > 0)
                {
                    NewDestination();
                }
            }
        }

        if (haspath)
        {
            //stop at a distance form the player
            if (!CheckSeePlayer() || Vector3.Distance(transform.position, player.transform.position) > 15)
            {
                MovePath();
            }

        }
    }

    private void MovePath()
    {
        if (pathindex < currentPath.Length)
        {
            for (int i = pathindex; i < currentPath.Length; i++)
            {
                if (i == pathindex)
                {
                    Debug.DrawLine(transform.position, currentPath[i],Color.red);
                }
                else
                {
                    Debug.DrawLine(currentPath[i], currentPath[i - 1], Color.red);
                }
            }
            if (Vector3.Distance(currentPath[pathindex], transform.position) < 1)
            {
                pathindex++;
                return;
            }

            direction.transform.position = transform.position;
            direction.transform.rotation = transform.rotation;
            direction.transform.LookAt(currentPath[pathindex]);
            bool prevRotate = startRotate;
            float currentrotation = Rotation360(transform.eulerAngles.y);
            float targetrotation = Rotation360(direction.transform.eulerAngles.y);

            //rotate
            if (Mathf.Abs(targetrotation - currentrotation) > 10)
            {
                startRotate = true;
                rigidbody.angularVelocity = new Vector3(rigidbody.angularVelocity.x, Mathf.Sign(Rotation360(targetrotation - currentrotation)) * rotationSpeed, rigidbody.angularVelocity.z);
                return;
            }
            //stop rotation
            if (prevRotate != startRotate)
            {
                rigidbody.angularVelocity = new Vector3(rigidbody.angularVelocity.x, 0, rigidbody.angularVelocity.z);
            }
            //move
            Vector3 currentspeed = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * rigidbody.velocity;
            rigidbody.velocity = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(currentspeed.x, currentspeed.y, movementSpeed);
            return;
        }
    }

    private void NewDestination()
    {
        //random destination number
        if (navPoints.Length == 1 && currentnavPoint == 0)
        {
            return;
        }
        int destinationNumber = Random.Range(0, navPoints.Length);
        if (destinationNumber != currentnavPoint)
        {
            currentnavPoint = destinationNumber;
            Vector3 destination = navPoints[destinationNumber].transform.position;
            SetDestination(destination);
        }
    }

    private void SetDestination(Vector3 destination)
    {
        //set pathfinding
        agent.Warp(transform.position);
        agent.CalculatePath(destination, path);
        if (path.corners.Length > 0)
        {
            pathindex = 0;
            currentPath = path.corners;
            haspath = true;
        }
    }

    private bool Timer()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            return false;
        }
        timer = 1;
        return true;
    }

    private bool CheckSeePlayer()
    {
        if (player == null)
        {
            return false;
        }

        for (int i = 0; i < seePoint.Count; i++)
        {
            seePoint[i].transform.LookAt(player.transform.position);

            RaycastHit hit;
            if (Physics.Raycast(seePoint[i].transform.position, seePoint[i].transform.forward, out hit, maxRange))
            {
                GameObject hitobject = hit.collider.transform.root.gameObject;
                PlayerController player = hitobject.GetComponent<PlayerController>();
                if (player != null)
                {
                    seeplayer = true;
                    return true;
                }
            }
        }
        return false;
    }

    private float Rotation360(float rotation)
    {
        if (rotation < -180)
        {
            rotation += 360;
        }
        if (rotation > 180)
        {
            rotation -= 360;
        }
        return rotation;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour {

    public Camera cam;
    public LineRenderer lr;
    public LayerMask grappleObjects;
    public float moveSpeed = 10;
    public float grappleLength = 10;
    public static bool grappled = false;
    [Min(1)]
    public int maxPoints = 1;

    private Rigidbody2D rig;
    private List<Vector2> points = new List<Vector2>();
    private bool grappleOn = PlayerTools.grappleOwn;

    private void Start() {
        rig = GetComponent<Rigidbody2D>();
        lr.positionCount = 0;
    }

    // Update is called once per frame
    void Update() {
        grappleOn = PlayerTools.grappleOwn;
        keyPressPhys();
        pointCounter();

        if (Input.GetKeyDown(KeyCode.Space)) {
            Detatch();
        }
    }

    public void Detatch() {
        grappled = false;
        lr.positionCount = 0;
        points.Clear();
    }

    Vector2 centriod(Vector2[] points) {
        Vector2 center = Vector2.zero;
        foreach (Vector2 point in points) {
            center += point;
        }
        center /= points.Length;
        return center;
    }
    
    private void pointCounter() {
        if (points.Count > 0) {
            Vector2 moveTo = centriod(points.ToArray());
            rig.MovePosition(Vector2.MoveTowards((Vector2)transform.position, moveTo, Time.deltaTime * moveSpeed));

            lr.positionCount = 0;
            lr.positionCount = points.Count * 2;
            for (int n = 0, j = 0; n < points.Count * 2; n += 2, j++) {
                lr.SetPosition(n, transform.position);
                lr.SetPosition(n + 1, points[j]);
            }
        }
    }

    private void keyPressPhys() {
        if (grappleOn) {
            if (Input.GetKey(KeyCode.E)) {
                grappled = true;
                Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, grappleLength, grappleObjects);
                if (hit.collider != null) {
                    Vector2 hitPoint = hit.point;
                    points.Add(hitPoint);

                    if (points.Count > maxPoints) {
                        points.RemoveAt(0);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direction);

        foreach (Vector2 point in points) {
            Gizmos.DrawLine(transform.position, point);
        }
    }
}
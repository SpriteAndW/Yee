
using UnityEngine;
using System.Linq;

namespace Werewolf.SpellIndicators {
  [RequireComponent(typeof(Projector))]
  public class Splat : MonoBehaviour {
    // Editor Fields
    [SerializeField]
    private TrackingMethod tracking = TrackingMethod.Facing;
    [SerializeField]
    private ScalingType scaling = ScalingType.None;
    [SerializeField]
    private float scale = 7f;
    [SerializeField]
    private float width = 5f;
    [SerializeField]
    private float offset = 0f;
    [SerializeField]
    private Vector3 origin = Vector3.zero;
    [SerializeField]
    private float range = 5f;
    [SerializeField]
    private bool showRangeIndicator = false;
    [SerializeField]
    private bool restrictCursorToRange = false;

    // Properties
    private Projector Projector { get { return GetComponent<Projector>(); } }

    /// <summary>
    /// Get the visibility status of the Splat.
    /// </summary>
    public virtual bool IsVisible { get { return Projector.enabled; } }

    /// <summary>
    /// The manager should contain all the splats for the character
    /// </summary>
    public SplatManager Manager { get; set; }

    /// <summary>
    /// Determine if you want the Splat origin to face or move towards the mouse cursor.
    /// </summary>
    public TrackingMethod Tracking {
      get { return tracking; }
      set { SetTrackingMethod(value); }
    }

    /// <summary>
    /// How the Splat should resize itself
    /// </summary>
    public ScalingType Scaling {
      get { return scaling; }
      set {
        scaling = value;
        UpdateScale();
      }
    }

    /// <summary>
    /// Size of the Splat in Length, or Length and Width depending on Scaling Type
    /// </summary>
    public float Scale {
      get { return scale; }
      set { SetScale(value, Width); }
    }


    /// <summary>
    /// Width of the Splat, when Scaling Type is Length Only
    /// </summary>
    public float Width {
      get { return width; }
      set { SetScale(Scale, value); }
    }

    /// <summary>
    /// The Z buffer between the character and projector
    /// </summary>
    public float Offset {
      get { return offset; }
      set {
        offset = value;
        UpdateScale();
      }
    }

    /// <summary>
    /// The Z buffer between the character and projector
    /// </summary>
    public Vector3 Origin {
      get { return origin; }
      set {
        origin = value;
        UpdateScale();
      }
    }

    /// <summary>
    /// Set the size of the Range Indicator and bounds of Spell Cursor
    /// </summary>
    public float Range {
      get { return range; }
      set { SetRange(value); }
    }

    /// <summary>
    /// Show the Splat specified by Splat type. Hides all other Splats in the container, so it only shows the Splat specified.
    /// </summary>
    /// <param name="type">The type of Splat you want to show.</param>
    public void Select() {
      if (this != Manager.RangeIndicator) {
        Manager.Splats.ToList().ForEach(x => x.SetVisible(x == this));
        Manager.CurrentSplat = this;
        UpdateRangeIndicatorSize();

        if (Manager != null)
          Manager.RangeIndicator.SetVisible(showRangeIndicator);
      }
    }

    /// <summary>
    /// Sets the visibility of the Splat by toggling the projector.
    /// </summary>
    public void SetVisible(bool visible) {
      Projector.enabled = visible;
    }

    void Start() {
      // We make all the Splats invisible to start with
      SetVisible(false);
    }

    /// <summary>
    /// Updates the rotation or position of the Splat.
    /// </summary>
    public void Update() {
      if (IsVisible) {
        switch (Tracking) {
          case TrackingMethod.Facing:
            Manager.transform.rotation = Quaternion.LookRotation(FlattenVector(Get3DMousePosition()) - Manager.transform.position);
            break;

          case TrackingMethod.Moving:
            transform.position = Get3DMousePosition();
            if (restrictCursorToRange)
              RestrictCursorToRange();
            break;

          case TrackingMethod.None:
            break;
        }
      }
    }

    /// <summary>
    /// Size of the Splat in Length, or Length and Width depending on Scaling Type
    /// </summary>
    public void SetScale(float scale, float width) {
      this.width = width;
      this.scale = scale;

      UpdateScale();
    }

    /// <summary>
    /// Determine if you want the Splat origin to face or move towards the mouse cursor.
    /// </summary>
    public void SetTrackingMethod(TrackingMethod tracking) {
      this.tracking = tracking;
      UpdateScale();
    }

    /// <summary>
    /// Get the vector that is on the same y position as the subject to get a more accurate angle.
    /// </summary>
    /// <param name="target">The target point which we are trying to adjust against</param>
    private Vector3 FlattenVector(Vector3 target) {
      return new Vector3(target.x, Manager.transform.position.y, target.z);
    }

    /// <summary>
    /// Finds the mouse position from the screen point to the 3D world.
    /// </summary>
    public static Vector3 Get3DMousePosition() {
      RaycastHit hit;
      if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 300.0f))
        return hit.point;
      else
        return Vector3.zero;
    }

    /// <summary>
    /// Resize the Splat in editor and game
    /// </summary>
    public void UpdateScale() {
      if (Scaling != ScalingType.None) {
        if (Scaling == ScalingType.LengthOnly) {
          Projector.aspectRatio = Width / Scale;
        } else {
          Projector.aspectRatio = 1f;
        }
        Projector.orthographicSize = Scale / 2;

        if (Manager != null && Tracking == TrackingMethod.Facing) {
          transform.position = Manager.transform.position + (Manager.transform.rotation * origin) + ((Manager.transform.forward * Scale) / 2f) + (Manager.transform.forward * offset * Scale);
        }
      }
    }

    /// <summary>
    /// Set the size of the Range Indicator and bounds of Spell Cursor
    /// </summary>
    /// <param name="range">Range of spell</param>
    public void SetRange(float range) {
      this.range = range;

      if (IsVisible)
        UpdateRangeIndicatorSize();
    }

    /// <summary>
    /// Scale indicator to be same as Range
    /// </summary>
    private void UpdateRangeIndicatorSize() {
      Manager.RangeIndicator.Scale = Range * 2.1f;
    }

    /// <summary>
    /// Restrict splat position bound to range from player
    /// </summary>
    private void RestrictCursorToRange() {
      if (Vector3.Distance(Manager.transform.position, transform.position) > Range)
        transform.position = Manager.transform.position + Vector3.ClampMagnitude(transform.position - Manager.transform.position, Range);
    }
  }
}

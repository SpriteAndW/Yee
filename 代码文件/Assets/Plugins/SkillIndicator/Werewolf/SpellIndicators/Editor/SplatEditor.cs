using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Linq;

namespace Werewolf.SpellIndicators.UI {
  [CustomEditor(typeof(Splat))]
  public class SplatEditor : Editor {
    private Splat splat { get { return (Splat)target; } }

    public override void OnInspectorGUI() {
      if (splat == null)
        return;

      EditorGUI.BeginChangeCheck();

      DrawDefaultInspector();

      if (EditorGUI.EndChangeCheck()) {
        //Don't apply manager if prefab
        if (splat.gameObject.scene.name != null)
          splat.Manager = splat.Manager ?? splat.transform.parent.GetComponent<SplatManager>();

        splat.UpdateScale();
      }
    }
  }
}

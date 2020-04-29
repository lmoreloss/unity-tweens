using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class LocalScaleTween {
    public static Tween<Vector3> TweenLocalScale (this Component self, Vector3 to, float duration) =>
      self.gameObject.TweenLocalScale (to, duration);

    public static Tween<Vector3> TweenLocalScale (this GameObject self, Vector3 to, float duration) =>
      self.AddComponent<Tween> ().Finalize (duration, to);

    private class Tween : Tween<Vector3> {
      public override bool OnInitialize () {
        return true;
      }

      public override Vector3 OnGetFrom () {
        return this.transform.localScale;
      }

      public override void OnUpdate (float easedTime) {
        this.valueCurrent.x = this.InterpolateValue (this.valueFrom.x, this.valueTo.x, easedTime);
        this.valueCurrent.y = this.InterpolateValue (this.valueFrom.y, this.valueTo.y, easedTime);
        this.valueCurrent.z = this.InterpolateValue (this.valueFrom.z, this.valueTo.z, easedTime);
        this.transform.localScale = this.valueCurrent;
      }
    }
  }
}
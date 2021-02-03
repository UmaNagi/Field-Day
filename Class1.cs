using System;
using MelonLoader;

namespace Modexample
{
    public class Class1 : MelonMod
    {
        public float timer;
        public override void OnUpdate()
        {
            base.OnUpdate();
            timer += UnityEngine.Time.deltaTime;
            if (timer < 12) return;
            timer = 0;
            MelonLogger.Msg("Wiping Shaders and Particles");
            foreach (var item in VRC.SDKBase.VRCPlayerApi.AllPlayers)
            {
                foreach (var _item in item.gameObject.GetComponentsInChildren<UnityEngine.MeshRenderer>())
                    _item.material.shader = UnityEngine.Shader.Find("Standard");

                foreach (var _item in item.gameObject.GetComponentsInChildren<UnityEngine.ParticleSystem>())
                    UnityEngine.Object.Destroy(_item);
            }
        }
    }

}
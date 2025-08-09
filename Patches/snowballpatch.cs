using HarmonyLib;
using UnityEngine;
using System.Reflection;

public static class CustomSnowballThrowPatch
{
    public static Vector3 customVelocity = Vector3.zero;
    public static bool ball;

    [HarmonyPatch(typeof(GrowingSnowballThrowable), "PerformSnowballThrowAuthority")]
    public static class Patch_GrowingPerformSnowballThrowAuthority
    {
        [HarmonyPrefix]
        static bool Prefix(GrowingSnowballThrowable __instance)
        {
            if (!ball)
                return true;

            ball = false;

            var modelT = __instance.snowballModelTransform;
            var pos = modelT.position;
            var scaleX = modelT.lossyScale.x;

            // Call inaccessible LaunchSnowballLocal via reflection
            var launchMethod = typeof(GrowingSnowballThrowable).GetMethod(
                "LaunchSnowballLocal",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                null,
                new System.Type[] { typeof(Vector3), typeof(Vector3), typeof(float) },
                null);

            if (launchMethod == null)
            {
                Debug.LogError("LaunchSnowballLocal method not found via reflection.");
                return true;
            }

            var proj = launchMethod.Invoke(__instance, new object[] { pos, customVelocity, scaleX }) as Component;
            if (proj == null)
            {
                Debug.LogError("LaunchSnowballLocal returned null projectile.");
                return true;
            }

            var projRenderer = proj.GetComponentInChildren<Renderer>();
            if (projRenderer != null)
                projRenderer.material.color = Color.red;

            // Disable snowball locally
            var setActiveMethod = __instance.GetType().GetMethod("SetSnowballActiveLocal", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (setActiveMethod != null)
                setActiveMethod.Invoke(__instance, new object[] { false });

            // Use reflection to check randModelIndex and localModels
            var randModelIndexField = __instance.GetType().GetField("randModelIndex", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var localModelsField = __instance.GetType().GetField("localModels", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            int randModelIndex = -1;
            object localModels = null;

            if (randModelIndexField != null)
                randModelIndex = (int)randModelIndexField.GetValue(__instance);

            if (localModelsField != null)
                localModels = localModelsField.GetValue(__instance);

            if (randModelIndex > -1 && localModels != null)
            {
                var list = localModels as System.Collections.IList;
                if (list != null && randModelIndex < list.Count)
                {
                    var model = list[randModelIndex];
                    var destroyAfterReleaseProp = model.GetType().GetProperty("destroyAfterRelease", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (destroyAfterReleaseProp != null)
                    {
                        bool destroyAfterRelease = (bool)destroyAfterReleaseProp.GetValue(model);
                        if (destroyAfterRelease)
                        {
                            // Invoke DestroyAfterRelease on proj if exists
                            var destroyMethod = proj.GetType().GetMethod("DestroyAfterRelease", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                            if (destroyMethod != null)
                                destroyMethod.Invoke(proj, null);
                        }
                    }
                }
            }

            // Setup TrailRenderer
            var trail = proj.gameObject.GetComponent<TrailRenderer>();
            if (trail == null)
                trail = proj.gameObject.AddComponent<TrailRenderer>();

            var material = new Material(Shader.Find("GUI/Text Shader"));
            trail.startWidth = 0.05f;
            trail.endWidth = 0f;
            trail.material = material;
            trail.startColor = Color.white;
            trail.endColor = Color.black;
            trail.time = 3f;

            // Raise snowballThrowEvent via reflection
            var eventField = __instance.GetType().GetField("snowballThrowEvent", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (eventField != null)
            {
                var evt = eventField.GetValue(__instance);
                if (evt != null)
                {
                    var raiseOthersMethod = evt.GetType().GetMethod("RaiseOthers");
                    if (raiseOthersMethod != null)
                    {
                        // Get myProjectileCount from proj if possible
                        int projectileCount = 0;
                        var projectileCountField = proj.GetType().GetField("myProjectileCount", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        var projectileCountProp = proj.GetType().GetProperty("myProjectileCount", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                        if (projectileCountField != null)
                            projectileCount = (int)projectileCountField.GetValue(proj);
                        else if (projectileCountProp != null)
                            projectileCount = (int)projectileCountProp.GetValue(proj);

                        raiseOthersMethod.Invoke(evt, new object[] { new object[] { pos, customVelocity, projectileCount } });
                    }
                }
            }

            return false; // Skip original method
        }
    }
}

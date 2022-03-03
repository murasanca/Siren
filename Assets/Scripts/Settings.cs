// murasanca

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.SystemInfo;

namespace murasanca
{
    public class Settings : MonoBehaviour
    {
        [SerializeField]
        private GameObject
            pB, // pB: Pitch Button.
            pS, // pS: Pitch Slider.
            pT, // pT: Pitch Text (TMP).
            vB, // vB: Volume Button.
            vS, // vS: Volume Slider.
            vT; // vT: Volume Text (TMP).

        [SerializeField]
        private GameObject[] gOs = new GameObject[3]; // gOs: Game Objects.

        private readonly Vector2 b = Siren.b; // b: Banner.

        private readonly Vector2[]
            v2s0 = new Vector2[8], // v2s0: Vector2's 0.
            v2s1 = new Vector2[8]; // v2s0: Vector2's 1.

        private readonly WaitForSeconds wFS = Siren.wFS; // wFS: Wait For Seconds.

        private static Button sB; // sB: Shield Button.

        private static GameObject checkmark, close;

        private static RawImage kLRI; // kLRI: Key Lock Raw Image;

        private static Texture2D
            k, // k: Key.
            l; // l: Lock.

        // Murat Sancak

        private Vector2[] Vector2s
        {
            get
            {
                if (!Monetization.IBL || IAP.HR())
                    return v2s0;
                else
                    return v2s1;
            }
        }

        // Murat Sancak

        private void Awake()
        {
            checkmark = GameObject.Find("Checkmark Button (Legacy)");
            close = GameObject.Find("Close Button");

            for (int i = 0; i < gOs.Length; i++)
            {
                v2s0[i] = b + gOs[i].GetComponent<RectTransform>().anchoredPosition;
                v2s1[i] = gOs[i].GetComponent<RectTransform>().anchoredPosition;
            }

            kLRI = GameObject.Find("Key Lock Raw Image").GetComponent<RawImage>();

            k = Resources.Load<Texture2D>("Key");
            l = Resources.Load<Texture2D>("Lock");

            sB = GameObject.Find("Shield Button").GetComponent<Button>();

            Close();

            pB.GetComponent<Button>().interactable = Preferences.P is 1;
            vB.GetComponent<Button>().interactable = Preferences.V is .64f;
            pS.GetComponent<Slider>().value = Preferences.P;
            vS.GetComponent<Slider>().value = Preferences.V;
        }

        private void Start() => StartCoroutine(Enumerator());

        // Murat Sancak

        private System.Collections.IEnumerator Enumerator()
        {
            while (true)
            {
                for (int i = 0; i < gOs.Length; i++)
                    gOs[i].GetComponent<RectTransform>().anchoredPosition = Vector2s[i];

                yield return wFS;
            }
        }

        // Murat Sancak

        public void Checkmark() => IAP.Checkmark();

        public void Load(int s) => Scene.Load(s); // s: Scene.

        public void Mail() => Application.OpenURL
        (
            string.Concat
            (
                "mailto:murasanca@pm.me?subject=Siren&body=%0A%0A%0A%0A%0AStatic Properties%0A%0A%0ABattery Level: ", batteryLevel,
                "%0ABattery Status: ", batteryStatus,

                "%0A%0AConstant Buffer Offset Alignment: ", constantBufferOffsetAlignment,

                "%0A%0ACopy Texture Support: ", copyTextureSupport,

                "%0A%0ADevice Model: ", deviceModel,
                "%0ADevice Name: ", deviceName,
                "%0ADevice Type: ", deviceType,
                "%0ADevice Unique Identifier: ", deviceUniqueIdentifier,

                "%0A%0AGraphics Device ID: ", graphicsDeviceID,
                "%0AGraphics Device Name: ", graphicsDeviceName,
                "%0AGraphics Device Type: ", graphicsDeviceType,
                "%0AGraphics Device Vendor: ", graphicsDeviceVendor,
                "%0AGraphics Device Vendor ID: ", graphicsDeviceVendorID,
                "%0AGraphics Device Version: ", graphicsDeviceVersion,
                "%0AGraphics Memory Size: ", graphicsMemorySize,
                "%0AGraphics Multi Threaded: ", graphicsMultiThreaded,
                "%0AGraphics Shader Level: ", graphicsShaderLevel,
                "%0AGraphics UV Starts At Top: ", graphicsUVStartsAtTop,

                "%0A%0AHas Dynamic Uniform Array Indexing In Fragment Shaders: ", hasDynamicUniformArrayIndexingInFragmentShaders,
                "%0AHas Hidden Surface Removal On GPU: ", hasHiddenSurfaceRemovalOnGPU,
                "%0AHas Mip Max Level: ", hasMipMaxLevel,

                "%0A%0AHDR Display Support Flags: ", hdrDisplaySupportFlags,

                "%0A%0AMax Compute Buffer Inputs Compute: ", maxComputeBufferInputsCompute,
                "%0AMax Compute Buffer Inputs Domain: ", maxComputeBufferInputsDomain,
                "%0AMax Compute Buffer Inputs Fragment: ", maxComputeBufferInputsFragment,
                "%0AMax Compute Buffer Inputs Geometry: ", maxComputeBufferInputsGeometry,
                "%0AMax Compute Buffer Inputs Hull: ", maxComputeBufferInputsHull,
                "%0AMax Compute Buffer Inputs Vertex: ", maxComputeBufferInputsVertex,
                "%0AMax Compute Work Group Size: ", maxComputeWorkGroupSize,
                "%0AMax Compute Work Group Size X: ", maxComputeWorkGroupSizeX,
                "%0AMax Compute Work Group Size Y: ", maxComputeWorkGroupSizeY,
                "%0AMax Compute Work Group Size Z: ", maxComputeWorkGroupSizeZ,
                "%0AMax Cubemap Size: ", maxCubemapSize,
                "%0AMax Texture Size: ", maxTextureSize,

                "%0A%0ANPOT Support: ", npotSupport,

                "%0A%0AOperating System: ", operatingSystem,
                "%0AOperating System Family: ", operatingSystemFamily,

                "%0A%0AProcessor Count: ", processorCount,
                "%0AProcessor Frequency: ", processorFrequency,
                "%0AProcessor Type: ", processorType,

                "%0A%0ARendering Threading Mode: ", renderingThreadingMode,

                "%0A%0ASupported Random Write Target Count: ", supportedRandomWriteTargetCount,
                "%0ASupported Render Target Count: ", supportedRenderTargetCount,

                "%0A%0ASupports 2D Array Textures: ", supports2DArrayTextures,
                "%0ASupports 32 Bits Index Buffer: ", supports32bitsIndexBuffer,
                "%0ASupports 3D Render Textures: ", supports3DRenderTextures,
                "%0ASupports 3D Textures: ", supports3DTextures,
                "%0ASupports Accelerometer: ", supportsAccelerometer,
                "%0ASupports Async Compute: ", supportsAsyncCompute,
                "%0ASupports Async GPU Readback: ", supportsAsyncGPUReadback,
                "%0ASupports Audio: ", supportsAudio,
                "%0ASupports Compressed 3D Textures: ", supportsCompressed3DTextures,
                "%0ASupports Compute Shaders: ", supportsComputeShaders,
                "%0ASupports Conservative Raster: ", supportsConservativeRaster,
                "%0ASupports Cubemap Array Textures: ", supportsCubemapArrayTextures,
                "%0ASupports Geometry Shaders: ", supportsGeometryShaders,
                "%0ASupports GPU Recorder: ", supportsGpuRecorder,
                "%0ASupports Graphics Fence: ", supportsGraphicsFence,
                "%0ASupports Gyroscope: ", supportsGyroscope,
                "%0ASupports Hardware Quad Topology: ", supportsHardwareQuadTopology,
                "%0ASupports Instancing: ", supportsInstancing,
                "%0ASupports Location Service: ", supportsLocationService,
                "%0ASupports Mip Streaming: ", supportsMipStreaming,
                "%0ASupports Motion Vectors: ", supportsMotionVectors,
                "%0ASupports Multisample Auto Resolve: ", supportsMultisampleAutoResolve,
                "%0ASupports Multisampled 2D Array Textures: ", supportsMultisampled2DArrayTextures,
                "%0ASupports Multisampled Textures: ", supportsMultisampledTextures,
                "%0ASupports Multiview: ", supportsMultiview,
                "%0ASupports Raw Shadow Depth Sampling: ", supportsRawShadowDepthSampling,
                "%0ASupports Ray Tracing: ", supportsRayTracing,
                "%0ASupports Render Target Array Index From Vertex Shader: ", supportsRenderTargetArrayIndexFromVertexShader,
                "%0ASupports Separated Render Targets Blend: ", supportsSeparatedRenderTargetsBlend,
                "%0ASupports Set Constant Buffer: ", supportsSetConstantBuffer,
                "%0ASupports Shadows: ", supportsShadows,
                "%0ASupports Sparse Textures: ", supportsSparseTextures,
                "%0ASupports Store And Resolve Action: ", supportsStoreAndResolveAction,
                "%0ASupports Tessellation Shaders: ", supportsTessellationShaders,
                "%0ASupports Texture Wrap Mirror Once: ", supportsTextureWrapMirrorOnce,
                "%0ASupports Vibration: ", supportsVibration,

                "%0A%0ASystem Memory Size: ", systemMemorySize,

                "%0A%0AUnsupported Identifier: ", unsupportedIdentifier,

                "%0A%0AUses Load Store Actions: ", usesLoadStoreActions,
                "%0AUses Reversed Z Buffer: ", usesReversedZBuffer,

                "%0A%0A%0A"
            )
        );

        public void PB() => pS.GetComponent<Slider>().value = 1; // PB: Pitch Button.

        public void PV() // PV: Pitch Value.
        {
            Preferences.P = Sound.BP = Sound.GP = Sound.OP = Sound.RP = pS.GetComponent<Slider>().value;

            pB.GetComponent<Button>().interactable = Preferences.P is not 1;
            pT.GetComponent<TextMeshProUGUI>().text = Preferences.P.ToString("F2");
        }

        public void Reload()
        {
            Close();

            PB();
            VB();
        }

        public void VB() => vS.GetComponent<Slider>().value = .64f; // VB: Volume Button.

        public void VV() // VV: Volume Value.
        {
            Preferences.V = Sound.BS = Sound.GS = Sound.OS = Sound.RS = vS.GetComponent<Slider>().value;

            vB.GetComponent<Button>().interactable = Preferences.V is not .64f;
            vT.GetComponent<TextMeshProUGUI>().text = Preferences.V.ToString("F2");
        }

        public static void Close()
        {
            checkmark.SetActive(false);
            close.SetActive(false);
            kLRI.texture = IAP.HR() ? k : l;
            sB.interactable = !IAP.HR() && IAP.II;
        }
    }
}

// Murat Sancak
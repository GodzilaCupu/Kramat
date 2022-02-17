// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/InputPlayer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputPlayer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputPlayer"",
    ""maps"": [
        {
            ""name"": ""Pemain"",
            ""id"": ""df50bb98-6851-4290-9ea8-5a48295ba423"",
            ""actions"": [
                {
                    ""name"": ""LookMouse"",
                    ""type"": ""Value"",
                    ""id"": ""466211f3-0933-48f8-88e6-99f75f21fed0"",
                    ""expectedControlType"": """",
                    ""processors"": ""Clamp(min=-90,max=90)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walking"",
                    ""type"": ""Value"",
                    ""id"": ""1e85388f-8ea9-403e-add0-211e0bce0870"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""2c3624d8-1af3-4c40-b89c-f5beffb7a405"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""PickObject"",
                    ""type"": ""Button"",
                    ""id"": ""74678e6b-524b-4693-b6cf-a07452b2ce1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Senter"",
                    ""type"": ""Button"",
                    ""id"": ""699879e9-e62c-4877-858d-5a7fa17a2853"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b7ee6d4c-73dc-4fa5-bc4b-166356fd8867"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""14c4d3d8-7b17-4cae-bd96-c706f5f63471"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""11ca9170-1a79-4e67-8802-28626eff4a79"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""69c934f9-682a-4b58-9ed6-32e02d2d9a27"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""78a87d96-e313-4861-8e98-93fb78d307b5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""a6db4b84-a8d6-42f9-9488-b116b1ba73e3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2ff80870-4b62-4958-925d-30bbbbda3303"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5e375e90-5849-407d-9d51-77ad46eaa7e9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5f81b50f-710a-4823-ad42-e8f7103cd1f1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2f6bdf95-59c5-46bf-a4c8-96c06e75fb32"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8d871f87-03dc-42e9-844a-a85115681784"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72924ae8-fb44-4b03-8d9a-bf558573031a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe652fba-7363-4ca1-a780-e7d89800da6b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Senter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD Shift"",
                    ""id"": ""0e4ec87f-bdee-4aed-a099-ce2a405d58e5"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""1eec8dcb-891c-458b-8bba-c5c06f5e4448"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""4b4a07ec-ba01-4bd9-b4ce-acbf1ec7a2a7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowShift"",
                    ""id"": ""95ef225d-1de7-4e16-bf3d-2552fc9bccfd"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""cd077e9b-d761-4f19-a8a7-84166877e417"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""f05024f2-b520-4f4a-9033-a03c85182b59"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GUI"",
            ""id"": ""a92b4482-74ff-4674-900d-7148adbecf48"",
            ""actions"": [
                {
                    ""name"": ""Conversation"",
                    ""type"": ""Button"",
                    ""id"": ""e88c80e3-2ed7-46cb-b948-39c0347d5eb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""57eec666-dc9f-4719-80aa-b2b921f7889a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4bc4bcfa-7a59-406c-bc4c-51436b1d0ea4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Conversation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9575d265-cf5e-4ced-a62b-d5cc1494949e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Desktop"",
            ""bindingGroup"": ""Desktop"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Pemain
        m_Pemain = asset.FindActionMap("Pemain", throwIfNotFound: true);
        m_Pemain_LookMouse = m_Pemain.FindAction("LookMouse", throwIfNotFound: true);
        m_Pemain_Walking = m_Pemain.FindAction("Walking", throwIfNotFound: true);
        m_Pemain_Sprint = m_Pemain.FindAction("Sprint", throwIfNotFound: true);
        m_Pemain_PickObject = m_Pemain.FindAction("PickObject", throwIfNotFound: true);
        m_Pemain_Senter = m_Pemain.FindAction("Senter", throwIfNotFound: true);
        // GUI
        m_GUI = asset.FindActionMap("GUI", throwIfNotFound: true);
        m_GUI_Conversation = m_GUI.FindAction("Conversation", throwIfNotFound: true);
        m_GUI_Pause = m_GUI.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Pemain
    private readonly InputActionMap m_Pemain;
    private IPemainActions m_PemainActionsCallbackInterface;
    private readonly InputAction m_Pemain_LookMouse;
    private readonly InputAction m_Pemain_Walking;
    private readonly InputAction m_Pemain_Sprint;
    private readonly InputAction m_Pemain_PickObject;
    private readonly InputAction m_Pemain_Senter;
    public struct PemainActions
    {
        private @InputPlayer m_Wrapper;
        public PemainActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @LookMouse => m_Wrapper.m_Pemain_LookMouse;
        public InputAction @Walking => m_Wrapper.m_Pemain_Walking;
        public InputAction @Sprint => m_Wrapper.m_Pemain_Sprint;
        public InputAction @PickObject => m_Wrapper.m_Pemain_PickObject;
        public InputAction @Senter => m_Wrapper.m_Pemain_Senter;
        public InputActionMap Get() { return m_Wrapper.m_Pemain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PemainActions set) { return set.Get(); }
        public void SetCallbacks(IPemainActions instance)
        {
            if (m_Wrapper.m_PemainActionsCallbackInterface != null)
            {
                @LookMouse.started -= m_Wrapper.m_PemainActionsCallbackInterface.OnLookMouse;
                @LookMouse.performed -= m_Wrapper.m_PemainActionsCallbackInterface.OnLookMouse;
                @LookMouse.canceled -= m_Wrapper.m_PemainActionsCallbackInterface.OnLookMouse;
                @Walking.started -= m_Wrapper.m_PemainActionsCallbackInterface.OnWalking;
                @Walking.performed -= m_Wrapper.m_PemainActionsCallbackInterface.OnWalking;
                @Walking.canceled -= m_Wrapper.m_PemainActionsCallbackInterface.OnWalking;
                @Sprint.started -= m_Wrapper.m_PemainActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PemainActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PemainActionsCallbackInterface.OnSprint;
                @PickObject.started -= m_Wrapper.m_PemainActionsCallbackInterface.OnPickObject;
                @PickObject.performed -= m_Wrapper.m_PemainActionsCallbackInterface.OnPickObject;
                @PickObject.canceled -= m_Wrapper.m_PemainActionsCallbackInterface.OnPickObject;
                @Senter.started -= m_Wrapper.m_PemainActionsCallbackInterface.OnSenter;
                @Senter.performed -= m_Wrapper.m_PemainActionsCallbackInterface.OnSenter;
                @Senter.canceled -= m_Wrapper.m_PemainActionsCallbackInterface.OnSenter;
            }
            m_Wrapper.m_PemainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LookMouse.started += instance.OnLookMouse;
                @LookMouse.performed += instance.OnLookMouse;
                @LookMouse.canceled += instance.OnLookMouse;
                @Walking.started += instance.OnWalking;
                @Walking.performed += instance.OnWalking;
                @Walking.canceled += instance.OnWalking;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @PickObject.started += instance.OnPickObject;
                @PickObject.performed += instance.OnPickObject;
                @PickObject.canceled += instance.OnPickObject;
                @Senter.started += instance.OnSenter;
                @Senter.performed += instance.OnSenter;
                @Senter.canceled += instance.OnSenter;
            }
        }
    }
    public PemainActions @Pemain => new PemainActions(this);

    // GUI
    private readonly InputActionMap m_GUI;
    private IGUIActions m_GUIActionsCallbackInterface;
    private readonly InputAction m_GUI_Conversation;
    private readonly InputAction m_GUI_Pause;
    public struct GUIActions
    {
        private @InputPlayer m_Wrapper;
        public GUIActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Conversation => m_Wrapper.m_GUI_Conversation;
        public InputAction @Pause => m_Wrapper.m_GUI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GUIActions set) { return set.Get(); }
        public void SetCallbacks(IGUIActions instance)
        {
            if (m_Wrapper.m_GUIActionsCallbackInterface != null)
            {
                @Conversation.started -= m_Wrapper.m_GUIActionsCallbackInterface.OnConversation;
                @Conversation.performed -= m_Wrapper.m_GUIActionsCallbackInterface.OnConversation;
                @Conversation.canceled -= m_Wrapper.m_GUIActionsCallbackInterface.OnConversation;
                @Pause.started -= m_Wrapper.m_GUIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GUIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GUIActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Conversation.started += instance.OnConversation;
                @Conversation.performed += instance.OnConversation;
                @Conversation.canceled += instance.OnConversation;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GUIActions @GUI => new GUIActions(this);
    private int m_DesktopSchemeIndex = -1;
    public InputControlScheme DesktopScheme
    {
        get
        {
            if (m_DesktopSchemeIndex == -1) m_DesktopSchemeIndex = asset.FindControlSchemeIndex("Desktop");
            return asset.controlSchemes[m_DesktopSchemeIndex];
        }
    }
    public interface IPemainActions
    {
        void OnLookMouse(InputAction.CallbackContext context);
        void OnWalking(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnPickObject(InputAction.CallbackContext context);
        void OnSenter(InputAction.CallbackContext context);
    }
    public interface IGUIActions
    {
        void OnConversation(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}

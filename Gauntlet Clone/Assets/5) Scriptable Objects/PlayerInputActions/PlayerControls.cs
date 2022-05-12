// GENERATED AUTOMATICALLY FROM 'Assets/5) Scriptable Objects/PlayerInputActions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""dadfbd0f-d11d-4f25-b475-5fb7e848e274"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""00814242-dd19-4f4d-923b-c65dba41ab00"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UsePotion"",
                    ""type"": ""Button"",
                    ""id"": ""3a990801-9664-4797-a72d-9f8a951bfc80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseAbility"",
                    ""type"": ""Button"",
                    ""id"": ""8025edc2-c3fa-4497-8733-8767e1316d23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""56cc75d7-77f0-4668-aa2e-2f2c8e5e26c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseCredit"",
                    ""type"": ""Button"",
                    ""id"": ""546ebfcd-1242-43bf-b4e3-e7503be49593"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AddCredit"",
                    ""type"": ""Button"",
                    ""id"": ""ddcdd532-aaff-424e-a694-ddf8fbdcbbb0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""17545181-bdf7-4b7b-82fc-7dd5b47f4493"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7908d60d-e158-43a0-adcf-2ac598d3f2d2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4e396e2e-e0b3-42fc-bb8a-9f7a016f20f7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1c52dd11-f741-4376-94ca-9bccb69b6442"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""47e8aa6b-8784-49c7-8b74-a9f81601388a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a0693add-f43f-4ef6-92f6-8a2c7e568991"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ca6cf86-1623-4112-adb5-0499943cc54c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UsePotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1c9b1c0-94a7-4ccd-a102-4ebc7be46fce"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UsePotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57c38269-5835-41d9-bc25-fea84016e3c1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de93a5b2-5312-4693-8c0a-8487b2ba8a6a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb3168df-8e9a-404a-9856-18f5548a158e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de3d7943-80b0-45a8-821e-43dfb8edb5b2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""032b78fa-76fc-4271-b03e-487244c05e95"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseCredit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed5f484b-d1df-43e9-89e2-806b6beb473b"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseCredit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6acedbe5-de68-4636-b5c4-f0efcaff2843"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddCredit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_UsePotion = m_Player.FindAction("UsePotion", throwIfNotFound: true);
        m_Player_UseAbility = m_Player.FindAction("UseAbility", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_UseCredit = m_Player.FindAction("UseCredit", throwIfNotFound: true);
        m_Player_AddCredit = m_Player.FindAction("AddCredit", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_UsePotion;
    private readonly InputAction m_Player_UseAbility;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_UseCredit;
    private readonly InputAction m_Player_AddCredit;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @UsePotion => m_Wrapper.m_Player_UsePotion;
        public InputAction @UseAbility => m_Wrapper.m_Player_UseAbility;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @UseCredit => m_Wrapper.m_Player_UseCredit;
        public InputAction @AddCredit => m_Wrapper.m_Player_AddCredit;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @UsePotion.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePotion;
                @UsePotion.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePotion;
                @UsePotion.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUsePotion;
                @UseAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseAbility;
                @UseAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseAbility;
                @UseAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseAbility;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @UseCredit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseCredit;
                @UseCredit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseCredit;
                @UseCredit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseCredit;
                @AddCredit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAddCredit;
                @AddCredit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAddCredit;
                @AddCredit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAddCredit;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @UsePotion.started += instance.OnUsePotion;
                @UsePotion.performed += instance.OnUsePotion;
                @UsePotion.canceled += instance.OnUsePotion;
                @UseAbility.started += instance.OnUseAbility;
                @UseAbility.performed += instance.OnUseAbility;
                @UseAbility.canceled += instance.OnUseAbility;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @UseCredit.started += instance.OnUseCredit;
                @UseCredit.performed += instance.OnUseCredit;
                @UseCredit.canceled += instance.OnUseCredit;
                @AddCredit.started += instance.OnAddCredit;
                @AddCredit.performed += instance.OnAddCredit;
                @AddCredit.canceled += instance.OnAddCredit;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnUsePotion(InputAction.CallbackContext context);
        void OnUseAbility(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnUseCredit(InputAction.CallbackContext context);
        void OnAddCredit(InputAction.CallbackContext context);
    }
}

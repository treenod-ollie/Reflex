using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reflex.Core;

public class GreetInstaller : MonoBehaviour, IInstaller
{
    // IInstaller 인터페이스의 메서드 구현
    public void InstallBindings(ContainerDescriptor descriptor)
    {
        // "World"라는 문자열을 Singleton으로 등록
        descriptor.AddSingleton("World");
        // Greeter 클래스와 IStartable 인터페이스를 사용하여 Singleton으로 등록
        // IStartable은 해당 객체이 초기화를 컨테이너 빌드 시에 수행하도록 강제하는 인터페이스
        descriptor.AddSingleton(typeof(Greeter), typeof(IStartable));
    }
}

using UnityEngine;
using Reflex.Core;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    // IInstaller 인터페이스의 메서드를 구현
    public void InstallBindings(ContainerDescriptor descriptor)
    {
        // "Hello"라는 문자열을 Singleton으로 등록
        descriptor.AddSingleton("Hello");
    }
}

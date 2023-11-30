﻿using System;
using FluentAssertions;
using Reflex.Core;
using Reflex.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace Reflex.Tests
{
    internal class ContainerDescriptorTests
    {
        private interface IValuable
        {
            int Value { get; set; }
        }

        private class Valuable : IValuable
        {
            public int Value { get; set; }
        }
        
        [Test]
        public void AddSingletonByValue_ValuableWithIDisposableAsContract_ShouldThrow()
        {
            var builder = new ContainerDescriptor("");
            Action addSingleton = () => builder.AddSingleton(new Valuable(), typeof(IDisposable));
            addSingleton.Should().ThrowExactly<ContractDefinitionException>();
        }
        
        [Test]
        public void AddSingletonByValue_ValuableWithObjectAndValuableAndIValuableAsContract_ShouldNotThrow()
        {
            var builder = new ContainerDescriptor("");
            Action addSingleton = () => builder.AddSingleton(new Valuable(), typeof(object), typeof(Valuable), typeof(IValuable));
            addSingleton.Should().NotThrow();
        }
        
        [Test]
        public void AddTransient_ValuableWithIDisposableAsContract_ShouldThrow()
        {
            var builder = new ContainerDescriptor("");
            Action addSingleton = () => builder.AddTransient(typeof(Valuable), typeof(IDisposable));
            addSingleton.Should().ThrowExactly<ContractDefinitionException>();
        }

        [Test]
        public void AddTransient_ValuableWithObjectAndValuableAndIValuableAsContract_ShouldNotThrow()
        {
            var builder = new ContainerDescriptor("");
            Action addSingleton = () => builder.AddTransient(typeof(Valuable), typeof(object), typeof(Valuable), typeof(IValuable));
            addSingleton.Should().NotThrow();
        }
        
        [Test]
        public void AddSingleton_ValuableWithIDisposableAsContract_ShouldThrow()
        {
            var builder = new ContainerDescriptor("");
            Action addSingleton = () => builder.AddSingleton(typeof(Valuable), typeof(IDisposable));
            addSingleton.Should().ThrowExactly<ContractDefinitionException>();
        }

        [Test]
        public void AddSingleton_ValuableWithObjectAndValuableAndIValuableAsContract_ShouldNotThrow()
        {
            var builder = new ContainerDescriptor("");
            Action addSingleton = () => builder.AddSingleton(typeof(Valuable), typeof(object), typeof(Valuable), typeof(IValuable));
            addSingleton.Should().NotThrow();
        }

        [Test]
        public void HasBinding_ShouldTrue()
        {
            var builder = new ContainerDescriptor("").AddSingleton(Debug.unityLogger);
            builder.HasBinding(Debug.unityLogger.GetType()).Should().BeTrue();
        }
        
        [Test]
        public void Build_CallBack_ShouldBeCalled()
        {
            Container container = null;
            var builder = new ContainerDescriptor("");
            builder.OnContainerBuilt += ContainerCallback;
            Action addSingleton = () => builder.AddSingleton(new Valuable(), typeof(IDisposable)).Build();
            void ContainerCallback(Container ctx)
            {
                container = ctx;
            }
            builder.Build();
            container.Should().NotBeNull();
        }
    }
}
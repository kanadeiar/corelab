// <auto-generated>
using System.Reflection;

namespace FxResources.Microsoft.Extensions.DependencyInjection.Abstractions
{
    internal static class SR { }
}
namespace System
{
    internal static partial class SR
    {
        private static global::System.Resources.ResourceManager s_resourceManager;
        internal static global::System.Resources.ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new global::System.Resources.ResourceManager(typeof(FxResources.Microsoft.Extensions.DependencyInjection.Abstractions.SR)));

        /// <summary>Multiple constructors accepting all given argument types have been found in type '{0}'. There should only be one applicable constructor.</summary>
        internal static string @AmbiguousConstructorMatch => GetResourceString("AmbiguousConstructorMatch", @"Multiple constructors accepting all given argument types have been found in type '{0}'. There should only be one applicable constructor.");
        /// <summary>Unable to locate implementation '{0}' for service '{1}'.</summary>
        internal static string @CannotLocateImplementation => GetResourceString("CannotLocateImplementation", @"Unable to locate implementation '{0}' for service '{1}'.");
        /// <summary>Unable to resolve service for type '{0}' while attempting to activate '{1}'.</summary>
        internal static string @CannotResolveService => GetResourceString("CannotResolveService", @"Unable to resolve service for type '{0}' while attempting to activate '{1}'.");
        /// <summary>A suitable constructor for type '{0}' could not be located. Ensure the type is concrete and services are registered for all parameters of a public constructor.</summary>
        internal static string @NoConstructorMatch => GetResourceString("NoConstructorMatch", @"A suitable constructor for type '{0}' could not be located. Ensure the type is concrete and services are registered for all parameters of a public constructor.");
        /// <summary>No service for type '{0}' has been registered.</summary>
        internal static string @NoServiceRegistered => GetResourceString("NoServiceRegistered", @"No service for type '{0}' has been registered.");
        /// <summary>Implementation type cannot be '{0}' because it is indistinguishable from other services registered for '{1}'.</summary>
        internal static string @TryAddIndistinguishableTypeToEnumerable => GetResourceString("TryAddIndistinguishableTypeToEnumerable", @"Implementation type cannot be '{0}' because it is indistinguishable from other services registered for '{1}'.");

    }
}
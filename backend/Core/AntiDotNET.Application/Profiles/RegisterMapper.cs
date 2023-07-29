using System.Reflection;
using AutoMapper;

namespace AntiDotNET.Application.Profiles;

public class RegisterMapper : Profile
{
    public RegisterMapper()
    {
        var types = GetMappableTypes(Assembly.GetExecutingAssembly());
        ApplyMappingProfiles(types);
    }
    
    private void ApplyMappingProfiles(IEnumerable<Type> types)
    {
        foreach (var type in types)
        {
            var model = Activator.CreateInstance(type);
            var mapToMethodInfo = type.GetMethod("MapTo") ?? 
                             type.GetInterface("IMappable", true)?.GetMethod("MapTo");

            var mapFromMethodInfo = type.GetMethod("MapFrom") ??
                                    type.GetInterface("IMappable", true)?.GetMethod("MapFrom");

            if (model != null)
            {
                mapToMethodInfo!.Invoke(model, new object[] { this });
                mapFromMethodInfo!.Invoke(model, new object[] { this });
            }
        }
    }
    
    private IEnumerable<Type> GetMappableTypes(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces().Any(i => i == typeof(IMappable)));
        return types;
    }
}
using LZSPatrimonio.Dominio.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LZSPatrimonio.Infra.Extensoes;

public static class EFFilterExtensions
{
    public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
    {
        SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
            .Invoke(null, new object[] { modelBuilder });
    }

    static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(EFFilterExtensions)
               .GetMethods(BindingFlags.Public | BindingFlags.Static)
               .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

    public static void SetSoftDeleteFilter<T>(this ModelBuilder modelBuilder)
        where T : class, IBaseEntity
    {
        modelBuilder.Entity<T>().HasQueryFilter(x => x.DeletadoEmUtc == null);
    }
}

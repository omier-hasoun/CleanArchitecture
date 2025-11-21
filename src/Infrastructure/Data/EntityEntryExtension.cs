// using Microsoft.EntityFrameworkCore.ChangeTracking;

// namespace Infrastructure.Data;

// public static class EntityEntryExtension
// {
//     public static bool HasChangedOwnedEntities(this EntityEntry entry)
//     {
//         foreach (var ownedEntity in entry.Navigations)
//         {
//             if (ownedEntity.EntityEntry.State is EntityState.Modified or EntityState.Added)
//             {
//                 return true;
//             }
//         }
//         return false;
//     }
// }

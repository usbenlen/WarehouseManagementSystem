using System;

namespace WarehouseManagementSystem.Shared.Utils;

public static class IdGenerator
{
    public static Guid Generate()
    {
        return Guid.NewGuid();
    }
}

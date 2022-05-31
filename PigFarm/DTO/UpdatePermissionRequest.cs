using System.Collections.Generic;


namespace PigFarm.DTO
{
    public class UpdatePermissionRequest
    {
        public List<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();
    }
}
